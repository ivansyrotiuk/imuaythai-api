using IMuaythai.JudgingServer.Handlers;

namespace IMuaythai.JudgingServer.RingMapping
{
    public class RingA : FightHandler
    {
        public RingA(WebSocketConnectionManager connectionManager, IMessageHandlerChainFactory messageHandlerChainFactory) : base(connectionManager, messageHandlerChainFactory)
        {
            Ring = "A";
        }
    }
}
