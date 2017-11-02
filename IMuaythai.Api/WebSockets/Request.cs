namespace IMuaythai.Api.WebSockets
{
    public enum RequestType
    {
        Connect,
        JuryConnected,
        Disconnect,
        SendPoints,
        StartRound,
        EndRound,
        AcceptPoints,
        PrematureEnd,
        ShowPrematureEndPanel,
        StartFight,
        EndFight,
        SendTime,
        PauseRound,
        ResumeRound
    }

    public class Request
    {
        public RequestType RequestType { get; set; }
        public string Data { get; set; }
    }
}