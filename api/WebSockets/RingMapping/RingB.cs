namespace MuaythaiSportManagementSystemApi.WebSockets.RingMapping
{
    public class RingB:FightHandler
    {
        public RingB(WebSocketConnectionManager connectionManager) : base(connectionManager)
        {
            Ring = "B";
        }
    }
}
