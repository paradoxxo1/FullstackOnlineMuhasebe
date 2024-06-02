using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndRoleRLFeatures;

public sealed class RemoveByIdMainRoleAndRoleRLCommandUnitTest
{
    private readonly Mock<IMainRoleAndRoleRelationshipService> _serviceMock;

    public RemoveByIdMainRoleAndRoleRLCommandUnitTest()
    {
        _serviceMock = new();
    }

    [Fact]
    public async Task MainRoleAndRoleRelationshipShouldNotBeNull()
    {
        _serviceMock.Setup(s =>
        s.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(new Domain.AppEntities.MainRoleAndRoleRelationship());

    }

    [Fact]
    public async Task RemoveByIdMainRoleAndRoleRLCommandResponseShouldNotBeNull()
    {
        RemoveByIdMainRoleAndRoleRLCommand removeByIdMainRoleAndRoleRLCommand = new(
            Id: "62e84bb7-2315-4df4-85d8-3ed81882b3d9");

        RemoveByIdMainRoleAndRoleRLCommandHandler handler = new(_serviceMock.Object);

        _serviceMock.Setup(s =>
            s.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new Domain.AppEntities.MainRoleAndRoleRelationship());


        RemoveByIdMainRoleAndRoleRLCommandResponse respone = await handler.Handle(removeByIdMainRoleAndRoleRLCommand, default);
        respone.ShouldNotBeNull();
        respone.Message.ShouldNotBeEmpty();

    }
}
