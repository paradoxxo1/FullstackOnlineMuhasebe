using OnlineMuhasebeServer.Domain;

namespace OnlineMuhasebeServer.Application.Services.AppService;

public interface IMainRoleService
{
    Task<MainRole> GetByTitleAndCompanyId(string title, string companyId, CancellationToken cancellationToken);
    Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken);

    Task CreateRangeAsync(List<MainRole> newMainRoles, CancellationToken cancellation);

    IQueryable<MainRole> GetAll();

}
