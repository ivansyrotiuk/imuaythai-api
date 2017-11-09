using IMuaythai.Fights;
using IMuaythai.Fights.Diagrams;
using Microsoft.Extensions.DependencyInjection;

namespace IMuaythai.Api.DepedencyInjection
{
    public static class FightsServicesDiConfiguration
    {
        public static void AddFightsServices(this IServiceCollection services)
        {
            services.AddScoped<IFightersTossupper, FightersTossupper>();
            services.AddScoped<IFightDurationCalculator, FightDurationCalculator>();
            services.AddScoped<IJudgesTossuper, JudgesTossuper>();
            services.AddScoped<IFightsDiagramBuilder, FightsDiagramBuilder>();
            services.AddScoped<IFighterMovingService, FighterMovingService>();
            services.AddScoped<IFightsIndexer, FightsIndexer>();
            services.AddScoped<IFightDrawsService, FightDrawsService>();
            services.AddScoped<IFightsService, FightsService>();
        }
    }
}