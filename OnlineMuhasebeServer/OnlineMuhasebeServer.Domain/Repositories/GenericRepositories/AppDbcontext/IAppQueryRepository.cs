using OnlineMuhasebeServer.Domain.Abstraction;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.AppDbcontext;

public interface IAppQueryRepository<T> : IQueryGenericRepository<T>, IRepository<T>
    where T : Entity
{
}
