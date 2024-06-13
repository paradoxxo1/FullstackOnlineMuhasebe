using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.LogRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Persistance.Repositories.CompanyDbContext.LogRepositories;

public class LogQueryRepository : CompanyDbQueryRepository<Log>, ILogQueryRepository
{

}
