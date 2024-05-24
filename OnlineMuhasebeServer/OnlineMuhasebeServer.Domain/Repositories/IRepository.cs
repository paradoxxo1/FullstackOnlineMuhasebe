using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstraction;

namespace OnlineMuhasebeServer.Domain.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
        void CreateDbContextInstance(DbContext context);
        DbSet<T> Entity { get; set; }
    }
}
