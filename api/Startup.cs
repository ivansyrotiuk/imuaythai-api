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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MuaythaiSportManagementSystemApi.Models.Comparers;
using Swashbuckle.AspNetCore.Swagger;

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
                options => options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging());

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
                {
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "IMuaythai API", Version = "v1" });
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey123456789"));

            services.AddWebSocketManager();
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateLifetime = false,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    options.RequireHttpsMetadata = false;
                });

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
            services.AddScoped<IFightDurationCalculator, FightDurationCalculator>();
            services.AddScoped<IJudgesTossuper, JudgesTossuper>();
            services.AddScoped<IFightsRepository, FightsRepository>();
            services.AddScoped<IFightsDiagramBuilder, FightsDiagramBuilder>();
            services.AddScoped<IFighterMovingService, FighterMovingService>();
            services.AddScoped<IFightsIndexer, FightsIndexer>();
            services.AddScoped<IFightDrawsService, FightDrawsService>();
            services.AddScoped<IFightsService, FightsService>();

            //add comparers
            services.AddScoped<IEqualityComparer<ContestCategoriesMapping>, ContestCategoriesMappingEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestCategory>, ContestCategoryEqualityComparer>();
            services.AddScoped<IEqualityComparer<Contest>, ContestEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestRange>, ContestRangeEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestRequest>, ContestRequestEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestType>, ContestTypeEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestTypePoints>, ContestTypePointsEqualityComparer>();
            services.AddScoped<IEqualityComparer<Fight>, FightEqualityComparer>();
            services.AddScoped<IEqualityComparer<FightJudgesMapping>, FightJudgesMappingEqualityComparer>();
            services.AddScoped<IEqualityComparer<FightStructure>, FightStructureEqualityComparer>();
            services.AddScoped<IEqualityComparer<Round>, RoundEqualityComparer>();
            services.AddScoped<IEqualityComparer<WeightAgeCategory>, WeightAgeCategoryEqualityComparer>();
            services.AddScoped<IEqualityComparer<ContestRing>, ContestRingEqualityComparer>();

            services.AddScoped<IDataTransferService, DataTransferService>();


            services.Configure<EmailConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IDataTransferService dataTransferService)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets(new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(25),

            });
            app.UseCors("MyPolicy");

            app.MapWebSocketManager("/ringa", serviceProvider.GetService<RingA>());
            app.MapWebSocketManager("/ringb", serviceProvider.GetService<RingB>());
            app.MapWebSocketManager("/ringc", serviceProvider.GetService<RingC>());

           //dataTransferService.UploadDataToMainDatabase(6).Wait();
            dataTransferService.DownloadDataFromMainDatabase();

            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMuathai API V1");
            });

            app.UseMvc();

        }
    }
}
