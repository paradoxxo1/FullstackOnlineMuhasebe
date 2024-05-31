using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstraction;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories;

public interface IRepository<T>
    where T : Entity
{
    DbSet<T> Entity { get; set; }

}
