using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Newtonsoft.Json.Serialization;
using MuaythaiSportManagementSystemApi.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Services;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Users;
using MuaythaiSportManagementSystemApi.Fights;
using MuaythaiSportManagementSystemApi.WebSockets;
using MuaythaiSportManagementSystemApi.WebSockets.RingMapping;

namespace MuaythaiSportManagementSystemApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                
                
                
                
            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddOptions();
            services.AddMvc().AddJsonOptions(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(config => {
                config.SignIn.RequireConfirmedEmail = true;
                config.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddWebSocketManager();

            // Add application services.
            services.AddScoped<IEmailSender, AuthMessageSender>();
            services.AddScoped<ISmsSender, AuthMessageSender>();
            services.AddScoped<IInstitutionsRepository, InstitutionsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IContestTypesRepository, ContestTypesRepository>();
            services.AddScoped<IContestRangesRepository, ContestRangesRepository>();
            services.AddScoped<IKhanLevelsRepository, KhanLevelRepository>();
            services.AddScoped<ISuspensionTypesRepository, SuspensionTypesRepository>();
            services.AddScoped<IFightRepository, FightRepository>();
            services.AddScoped<IContestTypePointsRepository, ContestTypePointsRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUserRoleRequestsRepository, UserRoleRequestsRepository>();
            services.AddScoped<IContestRepository, ContestRepository>();
            services.AddScoped<IContestCategoriesRepository, ContestCategoriesRepository>();
            services.AddScoped<IContestRequestRepository, ContestRequestRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IRoundsRepository, RoundsRepository>();
            services.AddScoped<IWeightAgeCategoriesRepository, WeightAgeCategoriesRepository>();
            services.AddScoped<IFightStructuresRepository, FightStructuresRepository>();
            services.AddScoped<IContestCategoryMappingsRepository, ContestCategoryMappingsRepository>();
            services.AddScoped<IContestRingsRepository, ContestRingsRepository>();

            services.AddScoped<IFightersTossupper, FightersTossupper>();
            services.AddScoped<IFightsRepository, FightsRepository>();
            services.AddScoped<IFightsDiagramBuilder, FightsDiagramBuilder>();

            services.Configure<EmailConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseCors("MyPolicy");            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey123456789"));
            app.UseJwtBearerAuthentication(new JwtBearerOptions(){
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = new TokenValidationParameters(){
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateLifetime = false,
                    ValidateIssuer = false,
                    ValidateAudience = false 
                }
            });

            app.MapWebSocketManager("/ringa", serviceProvider.GetService<RingA>());
            app.MapWebSocketManager("/ringb", serviceProvider.GetService<RingB>());
            app.MapWebSocketManager("/ringc", serviceProvider.GetService<RingC>());


            app.UseIdentity();
            app.UseMvc();
  
        }
    }
}
