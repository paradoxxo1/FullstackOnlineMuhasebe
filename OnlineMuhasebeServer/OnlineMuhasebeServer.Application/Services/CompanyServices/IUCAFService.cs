using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services.CompanyServices
{
    public interface IUCAFService
    {
        Task CreateUCAFAsync(CreateUCAFCommand request, CancellationToken cancellationToken);

        Task<UniformChartOfAccount> GetByCode(string code);
    }
}
