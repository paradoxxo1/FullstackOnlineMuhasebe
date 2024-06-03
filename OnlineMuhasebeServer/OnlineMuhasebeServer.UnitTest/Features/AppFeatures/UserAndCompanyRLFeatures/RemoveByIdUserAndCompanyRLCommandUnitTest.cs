using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.RemoveByIdUserAndCompanyRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.UserAndCompanyRLFeatures;

public sealed class RemoveByIdUserAndCompanyRLCommandUnitTest
{
    private readonly Mock<IUserAndCompanyRelationshipService> _serviceMock;

    public RemoveByIdUserAndCompanyRLCommandUnitTest()
    {
        _serviceMock = new();
    }

    [Fact]
    public async Task RemoveByIdUserAndCompanyRLCommandResponseShouldNotBeNull()
    {
        RemoveByIdUserAndCompanyRLCommand command = new(
            Id: "06c1aa06-e8ce-47f7-9e51-cba166b4c425");

        RemoveByIdUserAndCompanyRLCommandHandler handler = new(_serviceMock.Object);
        RemoveByIdUserAndCompanyRLCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
