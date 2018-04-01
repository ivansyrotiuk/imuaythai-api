namespace IMuaythai.JudgingServer
{
    public enum MessageType
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
        ResumeRound,
        PersisedState
    }

    public enum ResponseType
    {
        Skip,
        ToOne,
        ToSelf,
        ToAll    
    }

    public class Message
    {
        public MessageType RequestType { get; set; }
        public string Data { get; set; }
    }

    public class HandlerResponse
    {
        public ResponseType ResponseType { get; set; }
        public Message Message { get; set; }
    }
}