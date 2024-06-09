using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.UCAFFeatures;

public sealed class UpdateUCAFCommandUnitTest
{
    private readonly Mock<IUCAFService> _service;

    public UpdateUCAFCommandUnitTest()
    {
        _service = new();
    }

    [Fact]
    public async Task UniformChartOfAccountShouldNotBeNull()
    {
        _service.Setup(s =>
        s.GetByIdAsync(
            It.IsAny<string>(),
            It.IsAny<string>()))
            .ReturnsAsync(new UniformChartOfAccount());
    }

    [Fact]
    public async Task CheckNewUCAFCodeShouldBeNull()
    {
        string companyId = "bae564ec-844e-4f6c-b997-ec00486c70cb";
        string code = "100.01.001";
        UniformChartOfAccount ucaf = await _service.Object.GetByCodeAsync(companyId, code, default);
        ucaf.ShouldBeNull();
    }

    [Fact]
    public async Task UpdateUCAFCommandResponseShouldNotBeNull()
    {
        UpdateUCAFCommand command = new(
            Id: "02e571e0-e5c8-4eb1-b605-4340f7a01283",
            Code: "100.01.001",
            Name: "MERKEZ KASA",
            Type: "M",
            CompanyId: "bae564ec-844e-4f6c-b997-ec00486c70cbZ");

        await UniformChartOfAccountShouldNotBeNull();

        UpdateUCAFCommandHandler handler = new(_service.Object);
        UpdateUCAFCommandResponse response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
