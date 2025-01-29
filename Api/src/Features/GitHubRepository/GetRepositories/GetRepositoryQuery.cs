using BlipChallenge.Features.GitHubRepository.GetRepositories.Enums;

namespace BlipChallenge.Features.GitHubRepository.GetRepositories;

/// <summary>
/// Classe que representa a query para buscar repositórios no GitHub
/// </summary>
public class GetRepositoryQuery
{
    /// <summary>
    /// Nome do usuário do GitHub
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Nome da linguagem de programação que deseja buscar
    /// </summary>
    public string ProgrammingLanguage { get; set; } = string.Empty;

    /// <summary>
    /// Quantidade de repositórios que deseja retornar na busca
    /// </summary>
    public int Rows { get; set; } = 5;

    /// <summary>
    /// Tipo de repositório que deseja buscar, 0 = Usuário, 1 = Organização
    /// </summary>
    public ERepositoryType Type { get; set; } = ERepositoryType.User;
}