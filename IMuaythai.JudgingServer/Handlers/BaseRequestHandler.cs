using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.JudgingServer.Handlers
{
    abstract class BaseRequestHandler
    {
        protected readonly ApplicationDbContext Context;
        protected readonly IMessageHandler NextHandler;
        protected readonly IFightContext FightContext;

        protected BaseRequestHandler(IMessageHandler handler, IFightContext fightContext, ApplicationDbContext context)
        {
            NextHandler = handler;
            FightContext = fightContext;
            Context = context;
        }
    }
}