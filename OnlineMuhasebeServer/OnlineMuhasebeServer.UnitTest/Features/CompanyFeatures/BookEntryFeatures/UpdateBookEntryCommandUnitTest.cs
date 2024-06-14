using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.UpdateBookEntry;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.BookEntryFeatures;

public sealed class UpdateBookEntryCommandUnitTest
{

    private readonly Mock<IBookEntryService> _service;
    private readonly Mock<ILogService> _logService;
    private readonly Mock<IApiService> _apiService;

    public UpdateBookEntryCommandUnitTest()
    {
        _service = new();
        _logService = new();
        _apiService = new();
    }

    [Fact]
    public async Task UpdateBookEntryCommandResponseShouldNotBeNull()
    {

        string id = "2f819058-3a13-403f-9266-79350acfc93b";
        string companyId = "ae3d3b62-dcaf-4bbf-9c8c-7560fc758248";
        _service.Setup(s =>
        s.GetByIdAsync(id, companyId)).ReturnsAsync(new BookEntry());


        UpdateBookEntryCommand command = new(
            Id: id,
            CompanyId: companyId,
            Type: "Muavin",
            Description: "Yevmiye Fişi",
            Date: "12.02.2023");

        UpdateBookEntryCommandHandler handler = new(_service.Object, _logService.Object, _apiService.Object);
        UpdateBookEntryCommandResponse response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
