using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRL;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndUserRLFeaures;

public sealed class CreateMainRoleAndUserRLCommandUnitTest
{
    private readonly Mock<IMainRoleAndUserRelationshipService> _serviceMock;

    public CreateMainRoleAndUserRLCommandUnitTest()
    {
        _serviceMock = new();
    }
    [Fact]
    public async Task MainRoleAndUserRelationshipShouldBeNull()
    {
        MainRoleAndUserRelationship entity = await _serviceMock.Object.GetByUserIdCompanyIdAndMainRoleIdAsync(
            userId: "25463322-384b-45c2-8c5f-8cf4109a7075",
            companyId: "1f5a908a-22a5-45e3-b774-86104f8f023b",
            mainRoleId: "bba1b099-bc5e-4292-a7b4-7ab9b5fc33d8",
            cancellationToken: default);

        entity.ShouldBeNull();
    }
    [Fact]
    public async Task CreateMainRoleAndUserRLCommandResponseShouldNotBeNull()
    {
        CreateMainRoleAndUserRLCommand command = new(
            UserId: "25463322-384b-45c2-8c5f-8cf4109a7075",
            MainRoleId: "bba1b099-bc5e-4292-a7b4-7ab9b5fc33d8",
            CompanyId: "1f5a908a-22a5-45e3-b774-86104f8f023b");

        CreateMainRoleAndUserRLCommandHandler handler = new(_serviceMock.Object);
        CreateMainRoleAndUserRLCommandResponse response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
