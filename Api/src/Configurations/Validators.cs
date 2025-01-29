using BlipChallenge.Features.GitHubRepository.GetRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BlipChallenge.Configurations;

/// <summary>
///    Configura os validadores da aplicação
/// </summary>
public static class ConfigureValidator
{
    /// <summary>
    ///     Configura os validadores da aplicação
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<GetRepositoryQueryValidator>(ServiceLifetime.Transient);
        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;

        return services;
    }
}