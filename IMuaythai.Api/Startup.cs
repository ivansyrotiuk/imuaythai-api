using System;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using IMuaythai.DataAccess.Models;
using IMuaythai.JudgingServer.RingMapping;
using IMuaythai.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using IMuaythai.Api.DepedencyInjection;
using IMuaythai.Api.Validators;
using IMuaythai.Api.Validators.Account;
using IMuaythai.Api.Validators.Contest;
using IMuaythai.Api.Validators.Fights;
using IMuaythai.Api.Validators.Institutions;
using IMuaythai.Api.Validators.Locations;
using IMuaythai.Api.Validators.Roles;
using IMuaythai.Api.Validators.Users;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Services;
using IMuaythai.Fights;
using IMuaythai.Models.AccountModels;
using IMuaythai.Models.Contests;
using IMuaythai.Models.Institutions;
using IMuaythai.Models.Locations;
using IMuaythai.Models.Roles;
using IMuaythai.Models.Users;

namespace IMuaythai.Api
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
            services.AddMvc(options =>
                options.Filters.Add(typeof(ValidatorActionFilter))).AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ).AddFluentValidation();

            //Add validators
          
            services.AddValidators();
            services.AddTransient<IValidator<UserModel>, UsersValidator>();
            services.AddTransient<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddTransient<IValidator<UserRoleRequestModel>, UserRoleRequestValidator>();
            services.AddTransient<IValidator<RoleModel>, RoleValidator>();
            services.AddTransient<IValidator<CountryModel>, CountryValidator>();
            services.AddTransient<IValidator<FightMoving>, FightMovingValidator>();
            services.AddTransient<IValidator<FighterMoving>, FighterMovingValidator>();
            services.AddTransient<IValidator<ContestRequestModel>, ContestRequestValidator>();
            services.AddTransient<IValidator<ContestResponseModel>, ContestResponseValidator>();
            services.AddTransient<IValidator<ContestUpdateModel>, ContestUpdateValidator>();
            services.AddTransient<IValidator<InstitutionUpdateModel>, InstitutionUpdateValidator>();
            services.AddTransient<IValidator<FinishRegisterDto>, FinishRegisterDtoValidator>();
            services.AddTransient<IValidator<ForgotPasswordDto>, ForgotPasswordDtoValidator>();
            services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddTransient<IValidator<RegisterDto>, RegisterDtoValidator>();
            services.AddTransient<IValidator<ResetPasswordDto>, ResetPasswordDtoValidator>();
            services.AddTransient<IValidator<VerifyCodeDto>, VerifyCodeDtoValidator>();
            
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
            services.AddContestServices();
            services.AddDictionariesServices();
            services.AddDashboardServices();
            services.AddHttpServices();
            services.Configure<EmailConfiguration>(Configuration);
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
            app.UseCors("MyPolicy");

            app.MapWebSocketManager("/ringa", serviceProvider.GetService<RingA>());
            app.MapWebSocketManager("/ringb", serviceProvider.GetService<RingB>());
            app.MapWebSocketManager("/ringc", serviceProvider.GetService<RingC>());

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
