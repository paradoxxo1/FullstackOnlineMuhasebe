using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.RemoveByIdUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.UCAFFeatures;

public sealed class RemoveByIdUCAFCommandUnitTest
{
    private readonly Mock<IUCAFService> _ucafService;

    public RemoveByIdUCAFCommandUnitTest()
    {
        _ucafService = new();
    }

    [Fact]
    public async Task CheckRemoveByIdUcafIsGroupAndAvailableShouldBeTrue()
    {
        _ucafService.Setup(s =>
        s.CheckRemoveByIdUcafIsGroupAndAvailable(
            It.IsAny<string>(),
            It.IsAny<string>()))
            .ReturnsAsync(true);
    }

    [Fact]
    public async Task RemoveByIdUCAFCommandResponseShouldNotBeNull()
    {
        var command = new RemoveByIdUCAFCommand(
            Id: "02e571e0-e5c8-4eb1-b605-4340f7a01283",
            CompanyId: "bae564ec-844e-4f6c-b997-ec00486c70cb");

        await CheckRemoveByIdUcafIsGroupAndAvailableShouldBeTrue();

        var handler = new RemoveByIdUCAFCommandHandler(_ucafService.Object);

        RemoveByIdUCAFCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
