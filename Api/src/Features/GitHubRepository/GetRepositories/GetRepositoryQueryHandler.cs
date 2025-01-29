using BlipChallenge.Common.Interfaces;
using BlipChallenge.Common.Services.GithubApi;
using BlipChallenge.Features.GitHubRepository.GetRepositories.Enums;

namespace BlipChallenge.Features.GitHubRepository.GetRepositories;

/// <summary>
/// Handler para query de busca de repositórios
/// </summary>
/// <param name="gitHubApi"></param>
public class GetRepositoryQueryHandler(IGitHubApi gitHubApi) : IHandler<List<RepositoryViewModel>, GetRepositoryQuery>
{
    /// <summary>
    /// Método que executa a query de busca de repositórios
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<List<RepositoryViewModel>> HandleAsync(GetRepositoryQuery query, CancellationToken cancellationToken)
    {
        var repositories = query.Type switch
        {
            ERepositoryType.User => await gitHubApi.GetUserRepositoriesAsync(query.UserName),
            ERepositoryType.Organization => await gitHubApi.GetOrgRepositoriesAsync(query.UserName),
            _ => throw new ArgumentOutOfRangeException()
        };

        return repositories.Where(x => x.Language?.Equals(query.ProgrammingLanguage, StringComparison.OrdinalIgnoreCase) ?? false)
            .OrderBy(x => x.CreatedAt)
            .Take(query.Rows)
            .Select(x => new RepositoryViewModel(x))
            .ToList();
    }
}