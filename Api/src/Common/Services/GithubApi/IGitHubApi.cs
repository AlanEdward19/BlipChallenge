using Refit;

namespace BlipChallenge.Common.Services.GithubApi;

public interface IGitHubApi
{
    [Get("/users/{userName}/repos")]
    Task<List<GitHubRepositoryViewModel>> GetUserRepositoriesAsync(string userName);

    [Get("/orgs/{organizationName}/repos")]
    Task<List<GitHubRepositoryViewModel>> GetOrgRepositoriesAsync(string organizationName);
}