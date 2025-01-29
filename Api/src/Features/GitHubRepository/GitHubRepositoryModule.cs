using BlipChallenge.Common.Interfaces;
using BlipChallenge.Features.GitHubRepository.GetRepositories;

namespace BlipChallenge.Features.GitHubRepository;

public static class GitHubRepositoryModule
{
    public static IServiceCollection ConfigureGetRepositoriesRelatedDependencies(this IServiceCollection services)
    {
        services
            .AddHandlers();

        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<IHandler<List<RepositoryViewModel>, GetRepositoryQuery>, GetRepositoryQueryHandler>();
        
        return services;
    }
}