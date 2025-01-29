using FluentValidation;

namespace BlipChallenge.Features.GitHubRepository.GetRepositories;

/// <summary>
/// Validador para a query de busca de repositórios
/// </summary>
public class GetRepositoryQueryValidator : AbstractValidator<GetRepositoryQuery>
{
    /// <summary>
    /// Validações para a query de busca de repositórios
    /// </summary>
    public GetRepositoryQueryValidator()
    {
        RuleFor(x => x.UserName)
            .NotNull()
            .WithMessage("O nome do usuário/organização é obrigatório");
        
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("O nome do usuário/organização não pode ser vazio");
        
        RuleFor(x => x.ProgrammingLanguage)
            .NotNull()
            .WithMessage("O nome da linguagem de programação é obrigatório");
        
        RuleFor(x => x.ProgrammingLanguage)
            .NotEmpty()
            .WithMessage("O nome do linguagem de programação não pode ser vazio");
        
        RuleFor(x => x.Rows)
            .GreaterThan(0)
            .WithMessage("A quantidade de repositórios deve ser maior que 0");
        
        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Tipo de repositório inválido. Os valores aceitos são: User [0] e Organization [1]");
    }
}