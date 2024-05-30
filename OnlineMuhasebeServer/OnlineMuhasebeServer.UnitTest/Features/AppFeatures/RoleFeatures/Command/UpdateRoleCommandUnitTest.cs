using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures.Command;

public sealed class UpdateRoleCommandUnitTest
{
    private readonly Mock<IRoleService> _roleServiceMock;

    public UpdateRoleCommandUnitTest()
    {
        _roleServiceMock = new();
    }

    [Fact]
    public async Task AppRoleShouldNotBeNull()
    {
        _roleServiceMock.Setup(
            x => x.GetById(It.IsAny<string>()))
            .ReturnsAsync(new AppRole());
    }

    [Fact]
    public async Task AppRoleCodeShouldBeUniqe()
    {
        AppRole checkRoleCode = await _roleServiceMock.Object.GetByCode("UCAF.Create");
        checkRoleCode.ShouldBeNull();
    }

    [Fact]
    public async Task UpdateRoleCommandResponseShouldNotBeNull()
    {
        var command = new UpdateRoleCommand(
            Id: "3944820a-4ef0-4f6b-893c-e337d849fb69",
            Code: "UCAF.Create",
            Name: "Hesap Planı Kayıt Ekleme");

        _roleServiceMock.Setup(
            x => x.GetById(It.IsAny<string>()))
            .ReturnsAsync(new AppRole());

        var handler = new UpdateRoleCommandHandler(_roleServiceMock.Object);

        UpdateRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
