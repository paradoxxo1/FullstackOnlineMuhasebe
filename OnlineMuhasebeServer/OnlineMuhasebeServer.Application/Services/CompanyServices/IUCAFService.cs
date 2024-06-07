using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services.CompanyServices;

public interface IUCAFService
{
    Task CreateUCAFAsync(CreateUCAFCommand request, CancellationToken cancellationToken);
    Task<UniformChartOfAccount> GetByCodeAsync(string companyId, string code, CancellationToken cancellation);
    Task CreateMainUcafsToCompanyAsync(string companyId, CancellationToken cancellationToken);
    Task<IList<UniformChartOfAccount>> GetAllAsync(string companyId);
}
