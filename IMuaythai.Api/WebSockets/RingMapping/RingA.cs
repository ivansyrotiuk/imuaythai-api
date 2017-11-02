namespace IMuaythai.Api.WebSockets.RingMapping
{
    public class RingA : FightHandler
    {

        public RingA(WebSocketConnectionManager connectionManager) : base(connectionManager)
        {
            Ring = "A";
        }
    }
}
