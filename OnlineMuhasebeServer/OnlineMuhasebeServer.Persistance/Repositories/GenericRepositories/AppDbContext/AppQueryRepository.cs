﻿using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstraction;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.AppDbcontext;
using System.Linq.Expressions;

namespace OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.AppDbContext;

public class AppQueryRepository<T> : IAppQueryRepository<T>
    where T : Entity
{
    private static readonly Func<Context.AppDbContext, string, bool, Task<T>> GetByIdCompiled =
           EF.CompileAsyncQuery((Context.AppDbContext contex, string id, bool isTracking) =>

           isTracking == true
           ? contex.Set<T>().FirstOrDefault(p => p.Id == id)
           : contex.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == id));

    private static readonly Func<Context.AppDbContext, bool, Task<T>> GetFirstCompiled =
     EF.CompileAsyncQuery((Context.AppDbContext contex, bool isTracking) =>
     isTracking == true
     ? contex.Set<T>().FirstOrDefault()
     : contex.Set<T>().AsNoTracking().FirstOrDefault());


    private Context.AppDbContext _context;

    public AppQueryRepository(Context.AppDbContext context)
    {
        _context = context;
        Entity = context.Set<T>();
    }

    public DbSet<T> Entity { get; set; }



    public IQueryable<T> GetAll(bool isTracking = true)
    {
        var result = Entity.AsQueryable();
        if (!isTracking)
            result = result.AsNoTracking();
        return result;
    }

    public async Task<T> GetById(string id, bool isTracking = true)
    {
        return await GetByIdCompiled(_context, id, isTracking);
    }

    public async Task<T> GetFirst(bool isTracking = true)
    {
        return await GetFirstCompiled(_context, isTracking);
    }

    public async Task<T> GetFirstByExpiression(Expression<Func<T, bool>> expression, bool isTracking = true)
    {
        T entity = null;

        if (!isTracking)
            entity = await Entity.AsNoTracking().Where(expression).FirstOrDefaultAsync();
        else
            entity = await Entity.Where(expression).FirstOrDefaultAsync();

        return entity;


    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
    {
        var result = Entity.Where(expression);

        if (!isTracking)
            result = result.AsNoTracking();
        return result;
    }
}