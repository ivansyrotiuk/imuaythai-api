using IMuaythai.JudgingServer.Handlers;

namespace IMuaythai.JudgingServer.RingMapping
{
    public class RingC : FightHandler
    {
        public RingC(WebSocketConnectionManager connectionManager, IMessageHandlerChainFactory messageHandlerChainFactory) : base(connectionManager, messageHandlerChainFactory)
        {
            Ring = "C";
        }
    }
}
