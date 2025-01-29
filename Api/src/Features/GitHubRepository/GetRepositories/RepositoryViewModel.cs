using BlipChallenge.Common.Services.GithubApi;

namespace BlipChallenge.Features.GitHubRepository.GetRepositories;

/// <summary>
/// ViewModel para repositório
/// </summary>
public class RepositoryViewModel
{
    /// <summary>
    /// Nome do repositório
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Url do repositório
    /// </summary>
    public string HtmlUrl { get; private set; }

    /// <summary>
    /// Linguagem de programação do repositório
    /// </summary>
    public string? Language { get; private set; }

    /// <summary>
    /// Descrição do repositório
    /// </summary>
    public string? Description{ get; private set; }

    /// <summary>
    /// Data de criação do repositório
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Construtor padrão com todos os parâmetros
    /// </summary>
    /// <param name="name"></param>
    /// <param name="htmlUrl"></param>
    /// <param name="language"></param>
    /// <param name="description"></param>
    /// <param name="createdAt"></param>
    public RepositoryViewModel(string name, string htmlUrl, string? language, string? description, DateTime createdAt)
    {
        Name = name;
        HtmlUrl = htmlUrl;
        Language = language;
        Description = description;
        CreatedAt = createdAt;
    }

    /// <summary>
    /// Construtor com parâmetro de ViewModel do GitHub
    /// </summary>
    /// <param name="gitHubRepositoryViewModel"></param>
    public RepositoryViewModel(GitHubRepositoryViewModel gitHubRepositoryViewModel)
    {
        Name = gitHubRepositoryViewModel.Name;
        HtmlUrl = gitHubRepositoryViewModel.HtmlUrl;
        Language = gitHubRepositoryViewModel.Language;
        Description = gitHubRepositoryViewModel.Description;
        CreatedAt = gitHubRepositoryViewModel.CreatedAt;
    }
}