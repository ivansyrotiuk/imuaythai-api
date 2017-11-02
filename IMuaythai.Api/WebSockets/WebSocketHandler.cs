using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IMuaythai.Api.WebSockets
{
    public abstract class WebSocketHandler
    {
        protected WebSocketConnectionManager WebSocketConnectionManager { get; set; }
        protected JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        public WebSocketHandler(WebSocketConnectionManager webSocketConnectionManager)
        {
            WebSocketConnectionManager = webSocketConnectionManager;
        }

        public virtual async Task OnConnected(WebSocket socket)
        {
            WebSocketConnectionManager.AddSocket(socket);

            await SendMessageToAllAsync(new Request()
            {
                RequestType = RequestType.Connect,
                Data = $"{WebSocketConnectionManager.GetId(socket)} is now connected"
            }).ConfigureAwait(false);
        }

        public virtual async Task OnDisconnected(WebSocket socket)
        {
            var id = WebSocketConnectionManager.GetId(socket);
            var message = new Request()
            {
                RequestType = RequestType.Disconnect,
                Data = $"{id} disconnected"
            };
            await SendMessageToAllAsync(message);
            await WebSocketConnectionManager.RemoveSocket(id).ConfigureAwait(false);
        }

        public virtual async Task SendMessageAsync(WebSocket socket, Request message)
        {
            if (socket.State != WebSocketState.Open)
                return;
            try
            {
                var serializedMessage = JsonConvert.SerializeObject(message, _jsonSerializerSettings);
                await socket.SendAsync(buffer: new ArraySegment<byte>(array: Encoding.ASCII.GetBytes(serializedMessage),
                                                        offset: 0,
                                                        count: serializedMessage.Length),
                                                        messageType: WebSocketMessageType.Text,
                                                        endOfMessage: true,
                                                        cancellationToken: CancellationToken.None).ConfigureAwait(false);
            }
            catch
            {
                var s = WebSocketConnectionManager.GetId(socket);
                await WebSocketConnectionManager.RemoveSocket(s);
            }

        }

        public virtual async Task SendMessageAsync(string socketId, Request message)
        {
            await SendMessageAsync(WebSocketConnectionManager.GetSocketById(socketId), message).ConfigureAwait(false);
        }

        public virtual async Task SendMessageToAllAsync(Request message)
        {

            var sockets = WebSocketConnectionManager.GetAll();
            foreach (var pair in sockets)
            {
                try
                {
                    if (pair.Value.State == WebSocketState.Open)
                        await SendMessageAsync(pair.Value, message).ConfigureAwait(false);

                }
                catch
                {
                    var socketToRemove = WebSocketConnectionManager.GetId(pair.Value);
                    await WebSocketConnectionManager.RemoveSocket(socketToRemove);
                }

            }
        }



        public virtual async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, string serializedInvocationDescriptor)
        {
            await SendMessageAsync(socket, new Request()
            {
                RequestType = RequestType.Connect,
                Data = serializedInvocationDescriptor
            }).ConfigureAwait(false);
        }
    }
}