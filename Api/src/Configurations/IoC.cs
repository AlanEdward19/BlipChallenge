using BlipChallenge.Common;
using BlipChallenge.Features.GitHubRepository;

namespace BlipChallenge.Configurations;

public static class IoC
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.ConfigureGetRepositoriesRelatedDependencies()
            .ConfigureCommonRelatedDependencies();
    }
}