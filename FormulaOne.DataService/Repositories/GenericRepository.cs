﻿using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected AppDbContext _dbContext;
    public readonly ILogger _logger;
    internal DbSet<T> _dbSet;

    public GenericRepository(AppDbContext dbContext,
        ILogger logger)
    {
        _dbContext = dbContext;
        _logger = logger;

        _dbSet = dbContext.Set<T>();
    }
    
    public virtual Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Add(T entity)
    { 
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}