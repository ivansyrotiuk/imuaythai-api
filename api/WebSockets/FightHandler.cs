using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using MuaythaiSportManagementSystemApi.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MuaythaiSportManagementSystemApi.Extensions;

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
        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);
            var fights = _context.Fights.Where(f => f.Ring == Ring).OrderBy(f => f.StartDate).ToArray();
            await SendMessageAsync(socket, new Request
            {
                RequestType = RequestType.Fights,
                Data = JsonConvert.SerializeObject(fights)
            });
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
                    await SavePoints(request.Data);
                    await SendMessageToAllAsync(new Request
                    {
                        RequestType = request.RequestType,
                        Data = "Points has been accepted"
                    }, new List<string>());
                    break;

                case RequestType.SelectedFight:
                    var fightInfo = _context.Fights.FirstOrDefault(f => f.Id == request.Data.ToInt());
                    await SendMessageAsync(socket, new Request
                    {
                        RequestType = RequestType.SelectedFight,
                        Data = JsonConvert.SerializeObject(fightInfo)
                    });

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
                case RequestType.EndRound:
                case RequestType.StartFight:
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

        private Task SavePoints(string data)
        {
            _context.FightPoints
        }

        public override async Task OnDisconnected(WebSocket socket)
        {
            var socketId = WebSocketConnectionManager.GetId(socket);

            await base.OnDisconnected(socket);

            var message = new Request()
            {
                RequestType = RequestType.Disconnect,
                Data = $"{socketId} disconnected"
            };
            await SendMessageToAllAsync(message, new List<string>());
        }
    }
}