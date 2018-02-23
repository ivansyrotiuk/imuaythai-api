using IMuaythai.JudgingServer.Handlers;

namespace IMuaythai.JudgingServer.RingMapping
{
    public class RingB:FightHandler
    {
        public RingB(WebSocketConnectionManager connectionManager, IMessageHandlerChainFactory messageHandlerChainFactory) : base(connectionManager, messageHandlerChainFactory)
        {
            Ring = "B";
        }
    }
}
