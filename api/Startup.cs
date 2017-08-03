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

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddSingleton<IInstitutionsRepository, InstitutionsRepository>();
            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddSingleton<IContestTypesRepository, ContestTypesRepository>();
            services.AddSingleton<IContestRangesRepository, ContestRangesRepository>();
            services.AddSingleton<IKhanLevelsRepository, KhanLevelRepository>();
            services.AddSingleton<ISuspensionTypesRepository, SuspensionTypesRepository>();

            services.AddSingleton<IContestTypePointsRepository, ContestTypePointsRepository>();
            services.AddSingleton<ICountriesRepository, CountriesRepository>();
            services.AddSingleton<IRolesRepository, RolesRepository>();
            services.AddSingleton<IUserRoleRequestsRepository, UserRoleRequestsRepository>();
            services.AddSingleton<IContestRepository, ContestRepository>();
            services.AddSingleton<IContestCategoriesRepository, ContestCategoriesRepository>();
            services.AddSingleton<IContestRequestRepository, ContestRequestRepository>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.Configure<EmailConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();
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
         

            app.UseIdentity();
            app.UseMvc();
  
        }
    }
}
