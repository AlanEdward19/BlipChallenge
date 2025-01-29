using BlipChallenge.Common.Services.GithubApi;
using BlipChallenge.Features.GitHubRepository.GetRepositories;
using BlipChallenge.Features.GitHubRepository.GetRepositories.Enums;
using Moq;

namespace BlipChallenge.Tests.Integration;

public class GitHubRepositoryIntegrationTests
{
    private GetRepositoryQueryHandler _repositoryQueryHandler;

    public GitHubRepositoryIntegrationTests()
    {
        var mockGitHubApi = new Mock<IGitHubApi>();

        List<GitHubRepositoryViewModel> repositories =
        [
            new("repo1", "url1", "C#", null, new DateTime(2021, 1, 1)),
            new("repo2", "url2", "C#", null, new DateTime(2022, 2, 1)),
            new("repo3", "url3", "C#", null, new DateTime(2023, 3, 1)),
            new("repo3", "url3", "C#", null, new DateTime(2024, 4, 1)),
            new("repo3", "url3", "C#", null, new DateTime(2025, 5, 1)),
            
            new("repo1", "url1", "Java", null, new DateTime(2021, 1, 1)),
            new("repo2", "url2", "Java", null, new DateTime(2022, 2, 1)),
            new("repo3", "url3", "Java", null, new DateTime(2023, 3, 1)),
            
            new("repo1", "url1", "Python", null, new DateTime(2021, 1, 1)),
            new("repo2", "url2", "Python", null, new DateTime(2022, 2, 1)),
        ];

        mockGitHubApi.Setup(api => api.GetUserRepositoriesAsync("user"))
            .ReturnsAsync(repositories);

        mockGitHubApi.Setup(api => api.GetOrgRepositoriesAsync("organization"))
            .ReturnsAsync(repositories);

        _repositoryQueryHandler = new GetRepositoryQueryHandler(mockGitHubApi.Object);
    }

    [Theory]
    [InlineData("C#", 3)]
    [InlineData("C#", 4)]
    [InlineData("Java", 1)]
    [InlineData("C#", 5)]
    [InlineData("Java", 3)]
    [InlineData("Python", 2)]
    [InlineData("Python", 1)]
    public async Task
        GetRepositoryQueryHandler_ReturnsUserRepositories_WhenQueryIsUserType_WithCorrectNumberOfRepositoriesAndCorrectProgrammingLanguage(
            string programmingLanguage, int rows)
    {
        #region Arrange

        GetRepositoryQuery query = new GetRepositoryQuery
        {
            ProgrammingLanguage = programmingLanguage,
            Rows = rows,
            Type = ERepositoryType.User,
            UserName = "user"
        };

        #endregion

        #region Act

        var result = await _repositoryQueryHandler.HandleAsync(query, CancellationToken.None);

        #endregion

        #region Assert

        Assert.Equal(rows, result.Count);
        Assert.All(result, x => Assert.Equal(programmingLanguage, x.Language));
        
        for (int i = 0; i < result.Count - 1; i++)
            Assert.True(result[i].CreatedAt <= result[i + 1].CreatedAt);

        #endregion
    }
    
    [Theory]
    [InlineData("C#", 3)]
    [InlineData("C#", 4)]
    [InlineData("Java", 1)]
    [InlineData("C#", 5)]
    [InlineData("Java", 3)]
    [InlineData("Python", 2)]
    [InlineData("Python", 1)]
    public async Task
        GetRepositoryQueryHandler_ReturnsUserRepositories_WhenQueryIsOrganizationType_WithCorrectNumberOfRepositoriesAndCorrectProgrammingLanguage(
            string programmingLanguage, int rows)
    {
        #region Arrange

        GetRepositoryQuery query = new GetRepositoryQuery
        {
            ProgrammingLanguage = programmingLanguage,
            Rows = rows,
            Type = ERepositoryType.Organization,
            UserName = "organization"
        };

        #endregion

        #region Act

        var result = await _repositoryQueryHandler.HandleAsync(query, CancellationToken.None);

        #endregion

        #region Assert

        Assert.Equal(rows, result.Count);
        Assert.All(result, x => Assert.Equal(programmingLanguage, x.Language));
        
        for (int i = 0; i < result.Count - 1; i++)
            Assert.True(result[i].CreatedAt <= result[i + 1].CreatedAt);

        #endregion
    }
    
    [Theory]
    [InlineData(null, 3)]
    [InlineData("", 3)]
    [InlineData("C#", -1)]
    [InlineData("C#", 0)]
    public async Task GetRepositoryQueryHandler_ReturnsEmptyList_WhenQueryIsInvalid(string programmingLanguage, int rows)
    {
        #region Arrange

        GetRepositoryQuery query = new GetRepositoryQuery
        {
            ProgrammingLanguage = programmingLanguage,
            Rows = rows,
            Type = ERepositoryType.User,
            UserName = "user"
        };

        #endregion

        #region Act

        var result = await _repositoryQueryHandler.HandleAsync(query, CancellationToken.None);

        #endregion

        #region Assert

        Assert.Empty(result);

        #endregion
    }

    [Theory]
    [InlineData(null, 3)]
    [InlineData("", 3)]
    [InlineData("C#", -1)]
    [InlineData("C#", 0)]
    public async Task GetRepositoryQueryHandler_ReturnsEmptyList_WhenQueryIsInvalid_Organization(string programmingLanguage, int rows)
    {
        #region Arrange

        GetRepositoryQuery query = new GetRepositoryQuery
        {
            ProgrammingLanguage = programmingLanguage,
            Rows = rows,
            Type = ERepositoryType.Organization,
            UserName = "organization"
        };

        #endregion

        #region Act

        var result = await _repositoryQueryHandler.HandleAsync(query, CancellationToken.None);

        #endregion

        #region Assert

        Assert.Empty(result);

        #endregion
    }
}