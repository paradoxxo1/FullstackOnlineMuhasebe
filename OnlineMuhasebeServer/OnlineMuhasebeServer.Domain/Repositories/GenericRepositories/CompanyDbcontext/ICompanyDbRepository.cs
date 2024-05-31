using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstraction;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbcontext
{
    public interface ICompanyDbRepository<T> : IRepository<T>
        where T : Entity
    {
        void SetDbContextInstance(DbContext context);
    }
}
