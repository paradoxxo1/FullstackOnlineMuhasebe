using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.AppDbcontext;

namespace OnlineMuhasebeServer.Domain.Repositories.AppDbContext.CompanyRepositories;

public interface ICompanyCommandRepository : IAppCommandRepository<Company>
{
}
