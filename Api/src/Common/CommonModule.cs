using BlipChallenge.Common.Services.GithubApi;
using Refit;

namespace BlipChallenge.Common;

/// <summary>
///    Módulo para configuração de dependências comuns.
/// </summary>
public static class CommonModule
{
    /// <summary>
    /// Método para resolver as dependências comuns.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureCommonRelatedDependencies(this IServiceCollection services)
    {
        services
            .AddExternalApis();

        return services;
    }

    private static IServiceCollection AddExternalApis(this IServiceCollection services)
    {
        services.AddRefitClient<IGitHubApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://api.github.com");
                c.DefaultRequestHeaders.Add("User-Agent", "BlipChallengeApp");
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            });
        
        return services;
    }
}