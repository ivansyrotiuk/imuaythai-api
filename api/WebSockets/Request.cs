namespace MuaythaiSportManagementSystemApi.WebSockets
{
    public enum RequestType
    {
        Connect,
        JuryConnected,
        Disconnect,
        SendPoints,
        StartRound,
        EndRound,
        SelectedFight,
        AcceptPoints,
        PrematureEnd,
        FightPaused,
        ShowPrematureEndPanel,
        StartFight,
        EndFight,
        Fights,
    }

    public class Request
    {
        public RequestType RequestType { get; set; }
        public string Data { get; set; }
    }
}