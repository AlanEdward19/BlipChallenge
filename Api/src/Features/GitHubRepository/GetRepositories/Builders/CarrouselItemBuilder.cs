namespace BlipChallenge.Features.GitHubRepository.GetRepositories.Builders;

/// <summary>
/// Classe para construção de itens do carrossel
/// </summary>
public class CarrouselItemBuilder
{
    private readonly List<object> _items = new();

    /// <summary>
    /// Método para adicionar um item ao carrossel
    /// </summary>
    /// <param name="repository"></param>
    /// <returns></returns>
    public CarrouselItemBuilder AddItem(RepositoryViewModel repository)
    {
        _items.Add(new
        {
            header = new
            {
                type = "application/vnd.lime.media-link+json",
                value = new
                {
                    title = repository.Name,
                    text = repository.Description,
                    type = "text/plain"
                }
            }
        });
        return this;
    }

    /// <summary>
    /// Método para construir o carrossel
    /// </summary>
    /// <returns></returns>
    public object Build()
    {
        return new
        {
            itemType = "application/vnd.lime.document-select+json",
            items = _items
        };
    }
}