using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Data;
using IMuaythai.DataAccess.Models;
using IMuaythai.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
// ReSharper disable PossibleMultipleEnumeration

namespace IMuaythai.JudgingServer
{
    public class FightHandler : WebSocketHandler
    {
        private readonly ApplicationDbContext _context;
        private readonly SemaphoreSlim _mutex;
        private string _jurySocketId;
        private Dictionary<string, int> _fightWarnings;
        protected string Ring { get; set; }
        public FightHandler(WebSocketConnectionManager connectionManager) : base(connectionManager)
        {
            _context = new ApplicationDbContextFactory().CreateDbContext(new string[] { });
            _mutex = new SemaphoreSlim(1);
            _fightWarnings = GetFightDictionary();
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, string serializedInvocationDescriptor)
        {
            var request = JsonConvert.DeserializeObject<Request>(serializedInvocationDescriptor);

            await HandleRequest(socket, request);
        }

        private async Task HandleRequest(WebSocket socket, Request request)
        {
            switch (request.RequestType)
            {
                case RequestType.AcceptPoints:
                    await AcceptPoints(request.Data);
                    await SendMessageToAllAsync(new Request
                    {
                        RequestType = request.RequestType,
                        Data = "Points has been accepted"
                    });
                    break;

                case RequestType.JuryConnected:
                    _jurySocketId = WebSocketConnectionManager.GetId(socket);
                    await SendMessageToAllAsync(new Request
                    {
                        RequestType = request.RequestType,
                        Data = "Jury connected"
                    });
                    break;

                case RequestType.SendTime:
                case RequestType.PauseRound:
                case RequestType.ResumeRound:
                case RequestType.EndRound:
                case RequestType.ShowPrematureEndPanel:
                    await SendMessageToAllAsync(request);
                    break;

                case RequestType.SendPoints:
                    await SavePoints(request.Data);
                    await SendMessageAsync(_jurySocketId, request);
                    break;

                case RequestType.PrematureEnd:
                    await SaveInjury(request.Data);
                    await SendMessageAsync(_jurySocketId, request);
                    break;

                case RequestType.StartRound:
                    if (CanStartNewRound())
                    {
                        var roundId = GetRoundId();
                        await SendMessageToAllAsync(new Request
                        {
                            RequestType = request.RequestType,
                            Data = roundId
                        });
                    }
                    break;

                case RequestType.EndFight:
                    _roundCount = 0;
                    _fightWarnings = GetFightDictionary();
                    _jurySocketId = string.Empty;
                    await SaveWinner(request.Data);
                    await SendMessageToAllAsync(new Request
                    {
                        RequestType = request.RequestType,
                        Data = null
                    });
                    break;

            }


        }

        private bool CanStartNewRound()
        {
            return _fightWarnings["Cautions"] <= 3 && _fightWarnings["Warnings"] <= 3 && _fightWarnings["KnockDown"] <= 3;
        }

        private async Task SaveWinner(string data)
        {
            var fight = await _context.Fights.FirstOrDefaultAsync(f => f.Id == data.ToInt());
            var nextFight = await _context.Fights.FirstOrDefaultAsync(f => f.Id == fight.NextFightId);
            if (!string.IsNullOrEmpty(fight.WinnerId)) return;

            var totalBluePoints = CalculateTotalPoints(fight.BlueAthleteId, fight.Id);
            var totalRedPoints = CalculateTotalPoints(fight.RedAthleteId, fight.Id);

            if (Math.Abs(totalBluePoints.Result) < 0 || Math.Abs(totalRedPoints.Result) < 0)
                return;

            if (totalBluePoints.Result > totalRedPoints.Result)
            {
                fight.WinnerId = fight.BlueAthleteId;
                SetWinnerToNextFight(nextFight, fight.BlueAthleteId);
            }

            else
            {
                fight.WinnerId = fight.RedAthleteId;
                SetWinnerToNextFight(nextFight, fight.RedAthleteId);
            }


            await _context.SaveChangesAsync();

        }

        private void SetWinnerToNextFight(Fight nextFight, string athleteId)
        {
            if (nextFight == null)
                return;

            if (string.IsNullOrEmpty(nextFight.RedAthleteId))
            {
                nextFight.RedAthleteId = athleteId;
            }
            else
            {
                nextFight.BlueAthleteId = athleteId;
            }
        }

        private async Task<float> CalculateTotalPoints(string blueAthleteId, int id)
        {
            var points = await _context.FightPoints.Where(f => f.FightId == id && f.FighterId == blueAthleteId && f.Accepted).ToListAsync();
            return points.GroupBy(p => p.RoundId).Select(g => new
            {
                RoundId = g.Key,
                Points = CalculateMedian(g)
            })
            .ToList()
            .Sum(s => s.Points);
        }

        private float CalculateMedian(IGrouping<int, FightPoint> g)
        {
            int count = g.Count();
            var orderedPoints = g.OrderBy(p => p.Points);
            float median = orderedPoints.ElementAt(count / 2).Points + orderedPoints.ElementAt((count - 1) / 2).Points;
            return median / 2;
        }

        private async Task SaveInjury(string data)
        {
            var points = JsonConvert.DeserializeObject<FightPoint>(data);
            var fight = await _context.Fights.FirstOrDefaultAsync(f => f.Id == points.FightId);
            var nextFight = await _context.Fights.FirstOrDefaultAsync(f => f.Id == fight.NextFightId);
            if (string.IsNullOrEmpty(fight.WinnerId) && points.Accepted)
            {
                fight.WinnerId = points.FighterId == fight.BlueAthleteId ? fight.RedAthleteId : fight.BlueAthleteId;
                SetWinnerToNextFight(nextFight, points.FighterId);
            }
           
            _context.FightPoints.Add(points);
            await _mutex.WaitAsync();
            try
            {
                await _context.SaveChangesAsync();
            }
            finally
            {
                _mutex.Release();
            }


        }
        int _roundCount;
        private string GetRoundId()
        {
            _roundCount++;
            return _roundCount.ToString();
        }

        private async Task AcceptPoints(string data)
        {
            var pointsArray = JsonConvert.DeserializeObject<string[]>(data);
            foreach (var pointString in pointsArray)
            {
                var points = JsonConvert.DeserializeObject<FightPoint>(pointString);
                var entityPoints = await _context.FightPoints.FirstOrDefaultAsync(f =>
                f.FighterId == points.FighterId
                && f.JudgeId == points.JudgeId
                && f.RoundId == points.RoundId
                && f.FightId == points.FightId);
                if (entityPoints == null)
                    return;
                entityPoints.Accepted = points.Accepted;
                entityPoints.Points = points.Points;

                await _context.SaveChangesAsync();
            }

        }

        private async Task SavePoints(string data)
        {
            var points = JsonConvert.DeserializeObject<FightPoint>(data);
            AddToFightDictionary(points);
            _context.FightPoints.Add(points);
            await _mutex.WaitAsync();
            try
            {
                await _context.SaveChangesAsync();
            }
            finally
            {
                _mutex.Release();
            }

        }

        private Dictionary<string, int> GetFightDictionary()
        {
            return new Dictionary<string, int>()
            {
                {"Cautions", 0},
                {"Warnings", 0},
                {"KnockDown", 0},
                {"J", 0},
                {"X", 0}
            };
        }

        private void AddToFightDictionary(FightPoint points)
        {
            _fightWarnings[nameof(points.Cautions)] += points.Cautions;

            _fightWarnings[nameof(points.Warnings)] += points.Warnings;

            _fightWarnings[nameof(points.KnockDown)] += points.KnockDown;

            _fightWarnings[nameof(points.J)] += points.J;

            _fightWarnings[nameof(points.X)] += points.X;

        }
    }
}