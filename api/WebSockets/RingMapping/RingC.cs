namespace MuaythaiSportManagementSystemApi.WebSockets.RingMapping
{
    public class RingC : FightHandler
    {
        public RingC(WebSocketConnectionManager connectionManager) : base(connectionManager)
        {
            Ring = "C";
        }
    }
}
