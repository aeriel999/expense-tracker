using Mapster;
using Microsoft.OpenApi.Models;

namespace ExpenseTracker.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.ReferenceHandler =
                 System.Text.Json.Serialization.ReferenceHandler.Preserve;
             });

        services.AddSwagger()
                 .AddMappings();

        return services;
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Dashboard API", Version = "v1" });

            //Leave for full version
            //option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //{
            //    In = ParameterLocation.Header,
            //    Description = "Please enter a valid token",
            //    Name = "Authorization",
            //    Type = SecuritySchemeType.Http,
            //    BearerFormat = "JWT",
            //    Scheme = "Bearer"
            //});

            //option.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //    {
            //        new OpenApiSecurityScheme
            //        {
            //            Reference = new OpenApiReference
            //            {
            //                Type=ReferenceType.SecurityScheme,
            //                Id="Bearer"
            //            }
            //        },
            //        Array.Empty<string>()
            //    }
            //});
        });

        return services;
    }

    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        services.AddMapster();

        TypeAdapterConfig.GlobalSettings.Scan(typeof(DependencyInjection).Assembly);

        return services;
    }
}
