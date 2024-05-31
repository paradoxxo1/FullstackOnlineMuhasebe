using OnlineMuhasebeServer.Domain.Abstraction;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.AppDbcontext;

public interface IAppCommandRepository<T> : ICommandGenericRepository<T>, IRepository<T>
    where T : Entity
{
}
