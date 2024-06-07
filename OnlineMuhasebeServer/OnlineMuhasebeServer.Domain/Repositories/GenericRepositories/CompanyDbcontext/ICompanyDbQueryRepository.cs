using OnlineMuhasebeServer.Domain.Abstraction;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbcontext;

public interface ICompanyDbQueryRepository<T> : ICompanyDbRepository<T>, IQueryGenericRepository<T>
    where T : Entity
{
}
