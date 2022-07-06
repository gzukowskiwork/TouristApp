using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TouristAppBackend.Domain.Models;
using TouristAppBackend.Infrastructure.Security;
using TouristAppBackend.Persistance;

namespace TouristAppBackend.ServicesExtensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            opt.AddPolicy(name: "My CORS policy", builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();

            }));
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    //Type = SecuritySchemeType.OAuth2,
                    //Flows = new OpenApiOAuthFlows()
                    //{
                    //    AuthorizationCode = new OpenApiOAuthFlow
                    //    {
                    //        AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                    //        TokenUrl = new Uri("https://localhost:5001/connect/token"),
                    //        Scopes = new Dictionary<string, string>
                    //        {
                    //            {"TouristApp1", "Full access"}
                    //        }
                    //    }
                    //}
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
              Enter 'Bearer' [space] and then your token in the text input below.
              \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
            {
              new OpenApiSecurityScheme
              {
                Reference = new OpenApiReference
                  {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                  },
                  Scheme = "oauth2",
                  Name = "Bearer",
                  In = ParameterLocation.Header,

                },
                new List<string>()
              }
            });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TouristAppBackend",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Grzegorz",
                        Email = "gzukowskiwork@gmail.com",
                        Url = new Uri("https://www.facebook.com/grzes.zukowski")
                    }
                });
                var file = Path.Combine(AppContext.BaseDirectory, "TouristAppBackend.xml");
                c.IncludeXmlComments(file);
                c.OperationFilter<AuthorizationCheckOperationFilter>();
            });
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAuthentication("bearer")
            //    .AddJwtBearer("bearer", options =>
            //    {
            //        options.Authority = "https://localhost:5001";
            //        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            //        {
            //            ValidateAudience = false
            //        };
            //    });
            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x=>
                {
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
                });
        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("TouristApp", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "TouristApp1");
                });
            });
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<UserContext>();
        }
    }
}
