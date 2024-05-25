﻿using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance
{
    public sealed class ContextService : IContextService
    {
        private readonly AppDbContext _appcontext;

        public ContextService(AppDbContext appcontext)
        {
            _appcontext = appcontext;
        }

        public DbContext CreateDbContextInstance(string companyId)
        {
            Company company = _appcontext.Set<Company>().Find(companyId);
            return new CompanyDbContext(company);
        }
    }
}
