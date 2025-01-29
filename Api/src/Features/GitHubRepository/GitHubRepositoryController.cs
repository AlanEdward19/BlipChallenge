using BlipChallenge.Common.Interfaces;
using BlipChallenge.Features.GitHubRepository.GetRepositories;
using Microsoft.AspNetCore.Mvc;

namespace BlipChallenge.Features.GitHubRepository;

/// <summary>
/// Controladora para rotas relacionadas a repositórios do GitHub
/// </summary>
[ApiController]
[Route("[Controller]")]
public class GitHubRepositoryController : ControllerBase
{
    /// <summary>
    /// Retorna os repositórios mais antigos de acordo com a linguagem de programação
    /// </summary>
    /// <param name="query"></param>
    /// <param name="handler"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetOldestRepositoriesByProgrammingLanguage")]
    public async Task<IActionResult> GetRepositories([FromQuery] GetRepositoryQuery query,
        [FromServices] IHandler<List<RepositoryViewModel>, GetRepositoryQuery> handler,
        CancellationToken cancellationToken)
    {
        return Ok(await handler.HandleAsync(query, cancellationToken));
    }
}