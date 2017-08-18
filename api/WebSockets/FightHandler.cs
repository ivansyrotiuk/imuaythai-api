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

                case RequestType.SendPoints:
                    request.Data = SavePoints(request.Data);
                    await SendMessageAsync(_jurySocketId, request);
                    break;

                case RequestType.PrematureEnd:
                    await SendMessageToAllAsync(new Request
                    {
                        RequestType = request.RequestType,
                        Data = null
                    }, new List<string>());
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
                case RequestType.EndFight:
                case RequestType.ShowPrematureEndPanel:
                    await SendMessageToAllAsync(new Request
                    {
                        RequestType = request.RequestType,
                        Data = null
                    }, new List<string>() { _jurySocketId });
                    break;


            }


        }
        int roundCount = 0;
        private string GetRoundId()
        {
            roundCount++;
            return roundCount.ToString();
        }

        private async Task AcceptPoints(string data)
        {
            var points = JsonConvert.DeserializeObject<FightPoint>(data);
            var entityPoints = await _context.FightPoints.FirstOrDefaultAsync(f => f.Id == points.Id);
            entityPoints.Accepted = points.Accepted;
            entityPoints.Cautions = points.Cautions;
            entityPoints.J = points.J;
            entityPoints.KnockDown = points.KnockDown;
            entityPoints.Points = points.Points;
            entityPoints.Warnings = points.Warnings;
            entityPoints.X = points.X;
            entityPoints.RoundId = points.RoundId;

            await _context.SaveChangesAsync();
        }

        private string SavePoints(string data)
        {
           var points = JsonConvert.DeserializeObject<FightPoint>(data);
           _context.FightPoints.Add(points);
           _context.SaveChangesAsync();

           return JsonConvert.SerializeObject(points, _jsonSerializerSettings);
        }

        public override async Task OnDisconnected(WebSocket socket)
        {
            var socketId = WebSocketConnectionManager.GetId(socket);

            await base.OnDisconnected(socket);

           
        }
    }
}