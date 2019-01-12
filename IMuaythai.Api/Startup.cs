using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IMuaythai.Api.DepedencyInjection;
using IMuaythai.Api.Middleware;
using IMuaythai.DataAccess.Services;
using IMuaythai.JudgingServer.RingMapping;
using IMuaythai.Licenses;

namespace IMuaythai.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath);

            if (env.IsDevelopment())
            {
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            }
            else
            {
                builder.AddEnvironmentVariables();
            }

            Configuration = builder.Build();

            foreach (var pair in Configuration.AsEnumerable())
            {
                Console.WriteLine($"Config var: {pair.Key}={pair.Value}");
            }
        }

        public static IConfigurationRoot Configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext(Configuration);
            services.AddIdentity();
            services.AddCors();
            services.AddSwagger();
            services.AddJwt(Configuration);
            services.AddConfigurationMapping(Configuration);

            services.AddValidators();
            services.AddAutoMapper();
            services.AddFluentValidators();
            services.AddSharedServices();
            services.AddAuthServices();
            services.AddCommonServices();
            services.AddRepositories();
            services.AddDataServices();
            services.AddFightsServices();
            services.AddInstitutionsServices();
            services.AddWebSocketManager();
            services.AddUsersServices();
            services.AddLicenseServices();
            services.AddContestServices();
            services.AddDictionariesServices();
            services.AddDashboardServices();
            services.AddHttpServices();
            services.AddClients(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IDataTransferService dataTransferService)
        {
            if (CommandLineConfiguration.NeedInitLocal)
            {
                dataTransferService.DownloadDataFromMainDatabase();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets(new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(25),
            });
            app.UseCors("ImuaythaiPolicy");

            app.MapWebSocketManager("/ringa", serviceProvider.GetService<RingA>());
            app.MapWebSocketManager("/ringb", serviceProvider.GetService<RingB>());
            app.MapWebSocketManager("/ringc", serviceProvider.GetService<RingC>());

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMuaythai API V1");
              
            });

            app.ConfigureExceptionMiddleware();

            app.UseMvc();
        }
    }
}
