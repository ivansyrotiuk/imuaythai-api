using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using IMuaythai.JudgingServer.Handlers;
using Newtonsoft.Json;

namespace IMuaythai.JudgingServer
{
    public class FightHandler : WebSocketHandler
    {
        private readonly SemaphoreSlim _mutex;
        private string _jurySocketId;
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        protected string Ring { get; set; }
        private readonly IMessageHandler _messageHandler;

        public FightHandler(WebSocketConnectionManager connectionManager, IMessageHandlerChainFactory messageHandlerChainFactory) : base(connectionManager)
        {
            _messageHandler = messageHandlerChainFactory.CreateMessageHandlerChain();
            _mutex = new SemaphoreSlim(1);
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result,
            string serializedInvocationDescriptor)
        {
            var request = JsonConvert.DeserializeObject<Message>(serializedInvocationDescriptor);

            await HandleRequest(socket, request);
        }

        private async Task HandleRequest(WebSocket socket, Message message)
        {
            await _mutex.WaitAsync();
            try
            {
                HandleMainJuryConnection(socket, message);
                var handlerResponse = await _messageHandler.Handle(message);
                await ExcecuteResponse(socket ,handlerResponse);
            }
            finally
            {
                _mutex.Release();
            }
        }

        private void HandleMainJuryConnection(WebSocket socket, Message message)
        {
            if (message.RequestType == MessageType.JuryConnected)
            {
                _jurySocketId = WebSocketConnectionManager.GetId(socket);
            }

            if (message.RequestType == MessageType.EndFight)
            {
                _jurySocketId = string.Empty;
            }
        }

        private async Task ExcecuteResponse(WebSocket socket, HandlerResponse handlerResponse)
        {
            if (handlerResponse.ResponseType == ResponseType.ToAll)
            {
                await SendMessageToAllAsync(handlerResponse.Message);
            }
            if (handlerResponse.ResponseType == ResponseType.ToOne)
            {
                await SendMessageAsync(_jurySocketId, handlerResponse.Message);
            }

            if (handlerResponse.ResponseType == ResponseType.ToSelf)
            {
                var socketId = WebSocketConnectionManager.GetId(socket);
                await SendMessageAsync(socketId, handlerResponse.Message);
            }
        }
    }
}