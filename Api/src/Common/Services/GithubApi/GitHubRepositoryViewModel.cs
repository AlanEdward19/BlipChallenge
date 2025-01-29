using System.Text.Json.Serialization;

namespace BlipChallenge.Common.Services.GithubApi;

/// <summary>
/// ViewModel para representar um repositório do GitHub
/// </summary>
/// <param name="name"></param>
/// <param name="htmlUrl"></param>
/// <param name="language"></param>
/// <param name="description"></param>
/// <param name="createdAt"></param>
public class GitHubRepositoryViewModel(string name, string htmlUrl, string? language, string? description, DateTime createdAt)
{
    /// <summary>
    /// Nome do repositório
    /// </summary>
    public string Name { get; private set; } = name;

    /// <summary>
    /// Url do repositório
    /// </summary>
    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; private set; } = htmlUrl;

    /// <summary>
    /// Linguagem de programação do repositório
    /// </summary>
    public string? Language { get; private set; } = language;

    /// <summary>
    /// Descrição do repositório
    /// </summary>
    public string? Description{ get; private set; } = description;

    /// <summary>
    /// Data de criação do repositório
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; private set; } = createdAt;
}