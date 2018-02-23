using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.JudgingServer.Handlers
{
    public interface IMessageHandlerChainFactory
    {
        IMessageHandler CreateMessageHandlerChain();
    }

    public class MessageHandlerChainFactory : IMessageHandlerChainFactory
    {
        public IMessageHandler CreateMessageHandlerChain()
        {
            var fightContext = new FightContext();
            var context = new ApplicationDbContextFactory().CreateDbContext(new string[] { });

            var endFightHandler = new EndFightHandler(null, fightContext, context);
            var startRoundHandler = new StartRoundHandler(endFightHandler, fightContext, context);
            var sendPointsHandler = new SendPointsHandler(startRoundHandler, fightContext, context);
            var prematureEndHandler = new PrematureEndHandler(sendPointsHandler, fightContext, context);
            var showPrematureEndPanel = new ShowPrematureEndPanelHandler(prematureEndHandler, fightContext, context);
            var juryConnectedHandler = new JuryConnectedHandler(showPrematureEndPanel, fightContext, context);
            return new AcceptPointsHandler(juryConnectedHandler, fightContext, context);
        }
    }

}
