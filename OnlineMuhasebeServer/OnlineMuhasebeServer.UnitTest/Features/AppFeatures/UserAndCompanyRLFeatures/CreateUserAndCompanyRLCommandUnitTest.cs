using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.UserAndCompanyRLFeatures;

public sealed class CreateUserAndCompanyRLCommandUnitTest
{
    private readonly Mock<IUserAndCompanyRelationshipService> _serviceMock;

    public CreateUserAndCompanyRLCommandUnitTest()
    {
        _serviceMock = new();
    }

    [Fact]
    public async Task UserAndCompanyRelationshipShouldBeNull()
    {
        UserAndCompanyRelationship userAndCompanyRelationship = await _serviceMock.Object.GetByUserIdAndCompanyId(
            userId: "e4bf66cb-ded3-4f9f-84b5-b43c0fb217b7",
            companyId: "ee1c6f0b-1848-48e9-8532-e0f1135bdc44",
            cancellationToken: default);

        userAndCompanyRelationship.ShouldBeNull();
    }

    [Fact]
    public async Task CreateUserAndCompanyRLCommandResponseShouldNotBeNull()
    {
        CreateUserAndCompanyRLCommand command = new(
            AppUserId: "e4bf66cb-ded3-4f9f-84b5-b43c0fb217b7",
            CompanyId: "ee1c6f0b-1848-48e9-8532-e0f1135bdc44");

        CreateUserAndCompanyRLCommandHandler handler = new(_serviceMock.Object);

        CreateUserAndCompanyRLCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }

}
