using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using IMuaythai.Api.Validators;
using IMuaythai.Auth;
using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using IMuaythai.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RestEase;
using Swashbuckle.AspNetCore.Swagger;

namespace IMuaythai.Api
{
    public static class ServiceCollectionExtensions
    {
        public static void AddJwt(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var jwtConfiguration =  configuration.GetSection("Jwt").Get<JwtConfiguration>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey));

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
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "IMuaythai API", Version = "v1" }); });
        }

        public static void AddCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("ImuaythaiPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                    config.User.RequireUniqueEmail = true;
                }).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddDbContext(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging();
            });
        }

        public static void AddMvc(this IServiceCollection services)
        {
            services.AddMvc(options =>
                options.Filters.Add(typeof(ValidatorActionFilter))).AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ).AddFluentValidation();
        }

        public static void AddConfigurationMapping(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<EmailConfiguration>(configuration);
            services.Configure<JwtConfiguration>(configuration);
        }

        public static void AddClients(this IServiceCollection services)
        {
            var paymentsClient = RestEase.RestClient.For<IPayments24Client>("https://sandbox.przelewy24.pl/");
            services.AddSingleton<IPayments24Client>(paymentsClient);
        }
    }

    public interface IPayments24Client
    {
        [Post("trnVerify")]
        Task<Response<object>> Pay([Body(BodySerializationMethod.UrlEncoded)]Dictionary<string, object> body);
    }
}