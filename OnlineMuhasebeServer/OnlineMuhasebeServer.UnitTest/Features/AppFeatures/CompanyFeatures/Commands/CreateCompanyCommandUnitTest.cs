﻿using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.CompanyFeatures.Commands;

public sealed class CreateCompanyCommandUnitTest
{
    private readonly Mock<ICompanyService> _companyService;

    public CreateCompanyCommandUnitTest()
    {
        _companyService = new();
    }

    [Fact]
    public async Task CompanyShouldBeNull()
    {
        Company company = (await _companyService.Object.GetCompanyByName("Mahmut LTD ŞTİ"))!;
        company.ShouldBeNull();
    }

    [Fact]
    public async Task CreateCompanyCommandResponseShouldNotBeNull()
    {
        var command = new CreateCompanyCommand(
            Name: "Mahmut LTD ŞTİ",
            ServerName: "localhost",
            DatabaseName: "IronBrakerDb",
            UserId: "",
            Password: "");
        var handler = new CreateCompanyCommandHandler(_companyService.Object);

        CreateCompanyCommandResponse response = await handler.Handle(command, default);
        response.Message.ShouldNotBeEmpty();
    }
}
