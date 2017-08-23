using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MuaythaiSportManagementSystemApi.Extensions;
using MuaythaiSportManagementSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MuaythaiSportManagementSystemApi.WebSockets
{
    public class FightHandler : WebSocketHandler 
    {
        private readonly ApplicationDbContext _context;
        private string _jurySocketId;
        protected string Ring { get; set; }
        public FightHandler(ApplicationDbContext context, WebSocketConnectionManager connectionManager) : base (connectionManager)
        {
            _context = context;
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, string serializedInvocationDescriptor)
        {
            var request = JsonConvert.DeserializeObject<Request>(serializedInvocationDescriptor);

            await HandleRequest(socket, request);

        }

        private async Task HandleRequest(WebSocket socket,Request request)
        {
            switch (request.RequestType)
            {
                case RequestType.AcceptPoints:
                    await AcceptPoints(request.Data);
                    await SendMessageToAllAsync(new Request
                    {
                        RequestType = request.RequestType,
                        Data = "Points has been accepted"
                    }, new List<string>());
                    break;

                case RequestType.JuryConnected:
                    _jurySocketId = WebSocketConnectionManager.GetId(socket);
                    await SendMessageToAllAsync(new Request
                    {
                        RequestType = request.RequestType,
                        Data = "Jury connected"
                    }, new List<string>());
                    break;

                case RequestType.SendTime:
                    await SendMessageToAllAsync(request, new List<string>());
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
                var roundId =  GetRoundId();
                 await SendMessageToAllAsync(new Request
                    {
                        RequestType = request.RequestType,
                        Data = roundId
                    }, new List<string>());
                    break;
                    
                case RequestType.EndRound:
                case RequestType.ShowPrematureEndPanel:
                    await SendMessageToAllAsync(new Request
                    {
                        RequestType = request.RequestType,
                        Data = null
                    }, new List<string>() { _jurySocketId });
                    break;
                     case RequestType.EndFight:
                     roundCount = 0;
                    await SaveWinner(request.Data);
                    await SendMessageToAllAsync(new Request
                    {
                        RequestType = request.RequestType,
                        Data = null
                    }, new List<string>() { _jurySocketId });
                    break;

            }


        }

        private async Task SaveWinner(string data)
        {
            var fight = await _context.Fights.FirstOrDefaultAsync(f => f.Id == data.ToInt());
            if(!string.IsNullOrEmpty(fight.WinnerId)) return;

            var totalBluePoints = CalculateTotalPoints(fight.BlueAthleteId, fight.Id);
            var totalRedPoints = CalculateTotalPoints(fight.RedAthleteId, fight.Id);

            if(totalBluePoints.Result > totalRedPoints.Result)
                fight.WinnerId = fight.BlueAthleteId;
            else
                fight.WinnerId = fight.RedAthleteId;

            await _context.SaveChangesAsync();

        }

        private async Task<float> CalculateTotalPoints(string blueAthleteId, int id)
        {
            var points = await _context.FightPoints.Where(f => f.FightId == id && f.FighterId == blueAthleteId).ToListAsync();
            return points.GroupBy(p=> p.RoundId).Select(g => new {
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
            float median = orderedPoints.ElementAt(count/2).Points + orderedPoints.ElementAt((count-1)/2).Points;
            return median / 2;
        }

        private async Task SaveInjury(string data)
        {
             var points = JsonConvert.DeserializeObject<FightPoint>(data);
             var fight = await _context.Fights.FirstOrDefaultAsync(f => f.Id == points.FightId);
             fight.WinnerId = points.FighterId == fight.BlueAthleteId ? fight.RedAthleteId : fight.BlueAthleteId;
             _context.FightPoints.Add(points);
           await _context.SaveChangesAsync();
        }
        int roundCount = 0;
        private string GetRoundId()
        {
            roundCount++;
            return roundCount.ToString();
        }

        private async Task AcceptPoints(string data)
        {
            var pointsArray = JsonConvert.DeserializeObject<string[]>(data);
            foreach (var pointString in pointsArray)
            {
                var points = JsonConvert.DeserializeObject<FightPoint>(pointString);
                var entityPoints = await _context.FightPoints.FirstOrDefaultAsync(f=> 
                f.FighterId == points.FighterId 
                && f.JudgeId == points.JudgeId 
                && f.RoundId == points.RoundId
                && f.FightId == points.FightId);
                if(entityPoints == null)
                    return;
                entityPoints.Accepted = points.Accepted;
                entityPoints.Points = points.Points;

            await _context.SaveChangesAsync();
            }
            
        }

        private async Task SavePoints(string data)
        {
           var points = JsonConvert.DeserializeObject<FightPoint>(data);
           _context.FightPoints.Add(points);
           await _context.SaveChangesAsync();
        }

        public override async Task OnDisconnected(WebSocket socket)
        {
            var socketId = WebSocketConnectionManager.GetId(socket);

            await base.OnDisconnected(socket);

           
        }
    }
}