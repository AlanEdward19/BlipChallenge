using BlipChallenge.Common.Interfaces;
using BlipChallenge.Features.GitHubRepository.GetRepositories;
using BlipChallenge.Features.GitHubRepository.GetRepositories.Builders;
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
        CancellationToken cancellationToken, [FromQuery] bool shouldFormatToCarrousel = false)
    {
        List<RepositoryViewModel> response = await handler.HandleAsync(query, cancellationToken);

        if (shouldFormatToCarrousel)
        {
            CarrouselItemBuilder carrouselBuilder = new();
            
            foreach (var repo in response)
                carrouselBuilder.AddItem(repo);
            
            return Ok(carrouselBuilder.Build());
        }

        return Ok(response);
    }
}