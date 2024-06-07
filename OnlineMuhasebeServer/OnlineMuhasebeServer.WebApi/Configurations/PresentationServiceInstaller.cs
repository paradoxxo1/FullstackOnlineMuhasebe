﻿
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using OnlineMuhasebeServer.Prenstation;
using OnlineMuhasebeServer.WebApi.Middleware;

namespace OnlineMuhasebeServer.WebApi.Configurations;

public class PresentationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ExceptionMiddleware>();

        services.AddCors(options => options.AddDefaultPolicy(options =>
        {
            options.AllowAnyHeader().AllowCredentials().AllowAnyMethod().SetIsOriginAllowed(options => true);
        }));

        services.AddControllers()
            .AddApplicationPart(typeof(AssemblyReference).Assembly);


        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(setup =>
        {
            var jwtSecuritySheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {

              { jwtSecuritySheme, Array.Empty<string>() }

             });
        });

    }
}
