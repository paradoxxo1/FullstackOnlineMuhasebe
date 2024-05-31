using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbcontext;

namespace OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.UCAFRepositories
{
    public interface IUCAFQueryRepository : ICompanyDbQueryRepository<UniformChartOfAccount>
    {
    }
}
