using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Domain.Dtos;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Commands.Login;

public class LoginQueryHandler : ICommandHandler<LoginCommand, LoginQueryResponse>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly UserManager<AppUser> _userManager;
    private readonly IAuthService _authService;

    public LoginQueryHandler(IJwtProvider jwtProvider, UserManager<AppUser> userManager, IAuthService authService)
    {
        _jwtProvider = jwtProvider;
        _userManager = userManager;
        _authService = authService;
    }

    public async Task<LoginQueryResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser user = await _authService.GetByEmailOrUserNameAsync(request.EmailOrUserName);
        if (user == null) throw new Exception("Kullanıcı bulunamadı! ");

        var checkUser = await _authService.CheckPasswordAsync(user, request.Password);
        if (!checkUser) throw new Exception("Şifreniz Yanlış! ");

        IList<UserAndCompanyRelationship> companies = await _authService.GetCompanyListByUserIdAsync(user.Id);
        if (companies.Count() == 0) throw new Exception("Herhangi bir şirkete kayıtlı değilsiniz!");

        IList<CompanyDto> companiesDto = companies.Select(s => new CompanyDto(
            s.Company.Id, s.Company.Name)).ToList();

        LoginQueryResponse response = new(
            Token: await _jwtProvider.CreateTokenAsync(user),
            Email: user.Email,
            UserId: user.Id,
            NameLastName: user.NameLastName,
            Companies: companiesDto,
            Company: companiesDto[0],
            Year: DateTime.Now.Year);

        return response;
    }
}
