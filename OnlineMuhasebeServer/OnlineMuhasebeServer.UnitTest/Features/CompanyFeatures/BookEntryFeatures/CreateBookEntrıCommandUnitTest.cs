using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.BookEntryFeatures;

public sealed class CreateBookEntrıCommandUnitTest
{
    private readonly Mock<IBookEntryService> _service;
    private readonly Mock<ILogService> _logService;
    private readonly Mock<IApiService> _apiService;

    public CreateBookEntrıCommandUnitTest()
    {
        _service = new();
        _logService = new();
        _apiService = new();
    }

    [Fact]
    public async Task CreateBookEntryCommandResponseShouldNotBeNull()
    {
        CreateBookEntryCommand command = new(
            CompanyId: "6ddaf09b-ec35-4047-90df-ce87da1e9cc4",
            Type: "Muavin",
            Description: "Yevmiye Fişi",
            Date: "13.06.2024");

        CreateBookEntryCommandHandler handler = new(_service.Object, _logService.Object, _apiService.Object);
        CreateBookEntryCommandResponse response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
