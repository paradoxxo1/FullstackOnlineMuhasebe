using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyDbContext.ReportRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Persistance.Repositories.CompanyDbContext.ReportRepositories;

public class ReportCommandRepository : CompanyDbCommandRepository<Report>, IReportCommandRepository
{

}
