using System.ComponentModel;
using System.Text.Json;
using Microsoft.OpenApi.Models;

namespace BlipChallenge.Configurations;

/// <summary>
///     Configuração dos Endpoints
/// </summary>
public static class EndpointsConfiguration
{
    /// <summary>
    ///     Mapeia os endpoint.
    /// </summary>
    /// <param name="app">The app.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>An IEndpointRouteBuilder.</returns>
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app, IConfiguration configuration)
    {
        var healthCheck = configuration["EndPointsConfig:HealthCheckPath"];

        app.MapHealthChecks(healthCheck!);
        app.MapControllers();
        return app;
    }

    /// <summary>
    ///     Configura os endpoints.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureEndpoints(this IServiceCollection services)
    {
        #region API Docs

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Blip Challenge",
                Version = "v1",
                Description = """
                              Este repositório contém o código fonte do desafio técnico da Take Blip.
                              """,
                Contact = new OpenApiContact
                {
                    Name = "Alan Oliveira",
                    Email = "alan-edward@outlook.com.br",
                    Url = new Uri("https://github.com/AlanEdward19")
                }
            });

            #region Servers

            c.AddServer(new OpenApiServer
            {
                Url = "https://localhost:5000",
                Description = "Local"
            });

            #endregion

            c.CustomSchemaIds(x =>
                x.GetCustomAttributes(false).OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? x.Name);

#if DEBUG
            Directory.GetFiles("./Configurations/Comments/", "*.xml", SearchOption.TopDirectoryOnly).ToList()
                .ForEach(xml => c.IncludeXmlComments(xml));
#endif
            
        });

        #endregion

        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });

        services.AddHealthChecks();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}