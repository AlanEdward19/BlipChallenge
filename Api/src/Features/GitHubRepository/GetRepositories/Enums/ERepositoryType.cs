namespace BlipChallenge.Features.GitHubRepository.GetRepositories.Enums;

/// <summary>
/// Enum que representa o tipo de repositório que deseja buscar
/// </summary>
public enum ERepositoryType
{
    /// <summary>
    /// Repositório de usuário
    /// </summary>
    User = 0,
    
    /// <summary>
    /// Repositório de organização
    /// </summary>
    Organization = 1
}