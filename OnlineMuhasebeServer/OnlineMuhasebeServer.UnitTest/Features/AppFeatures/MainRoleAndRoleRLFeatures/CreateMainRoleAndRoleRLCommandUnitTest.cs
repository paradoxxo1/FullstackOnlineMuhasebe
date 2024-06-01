using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRoleRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndRoleRLFeatures;

public sealed class CreateMainRoleAndRoleRLCommandUnitTest
{
    private readonly Mock<IMainRoleAndRoleRelationshipService> _service;

    public CreateMainRoleAndRoleRLCommandUnitTest()
    {
        _service = new();
    }

    [Fact]
    public async Task MainRoleAndRoleRelationshipShouldBeNull()
    {
        MainRoleAndRoleRelationship entitiy = (await _service.Object.GetByRoleIdAndMainRoleId(
           roleId: "baddd4d3-d189-4530-a815-972d6cb0a92a",
           mainRoleId: "82702b49-3e6c-4661-9cdd-d6277ef3877c",
           cancellationToken: default));
        entitiy.ShouldBeNull();
    }

    [Fact]
    public async Task CreateMainRoleAndRoleRLCommandResponseShouldNotBeNull()
    {
        var command = new CreateMainRoleAndRoleRLCommand(
            RoleId: "baddd4d3-d189-4530-a815-972d6cb0a92a",
            MainRoleId: "82702b49-3e6c-4661-9cdd-d6277ef3877c"
            );
        var handler = new CreateMainRoleAndRoleRLCommandHandler(_service.Object);

        CreateMainRoleAndRoleRLCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
