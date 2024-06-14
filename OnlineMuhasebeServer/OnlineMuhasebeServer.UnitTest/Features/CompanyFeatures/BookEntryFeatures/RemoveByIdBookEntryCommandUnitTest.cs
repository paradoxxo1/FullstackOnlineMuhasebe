using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.RemoveByIdBookEntry;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.BookEntryFeatures;

public sealed class RemoveByIdBookEntryCommandUnitTest
{
    private readonly Mock<IBookEntryService> _service;
    private readonly Mock<ILogService> _logService;
    private readonly Mock<IApiService> _apiService;

    public RemoveByIdBookEntryCommandUnitTest()
    {
        _service = new();
        _logService = new(); ;
        _apiService = new();
    }

    [Fact]
    public async Task RemoveByIdBookEntryCommandResponseShouldNotBeNull()
    {
        RemoveByIdBookEntryCommand command = new(
            Id: "2f819058-3a13-403f-9266-79350acfc93b",
            CompanyId: "ae3d3b62-dcaf-4bbf-9c8c-7560fc758248");

        RemoveByIdBookEntryCommandHandler handler = new RemoveByIdBookEntryCommandHandler(_service.Object, _logService.Object, _apiService.Object);

        RemoveByIdBookEntryCommandResponse response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();

    }

}