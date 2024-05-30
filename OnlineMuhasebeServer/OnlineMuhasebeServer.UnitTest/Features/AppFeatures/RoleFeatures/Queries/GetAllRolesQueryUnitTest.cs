using Moq;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures.Queries;

public sealed class GetAllRolesQueryUnitTest
{
    private readonly Mock<IRoleService> _roleServiceMock;

    public GetAllRolesQueryUnitTest()
    {
        _roleServiceMock = new();
    }

    [Fact]
    public async Task GetAllRolesQueryResponseShouldNotBeNull()
    {
        _roleServiceMock.Setup(
            x => x.GetAllRolesAsync())
            .ReturnsAsync(new List<AppRole>());

    }
}


