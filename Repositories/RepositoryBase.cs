﻿using AutoMapper;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class RepositoryBase<TEntity, T> : IRepositoryBase<TEntity, T>
        where TEntity : Entity<T>, new()
        where T : IEquatable<T>
    {
        public RepositoryBase(SchedulerContext context, DbSet<TEntity> dbset)
        {
            Context = context;
            Data = dbset;
        }

        public SchedulerContext Context { get; }
        public DbSet<TEntity> Data { get; }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var entities = await Data.ToListAsync();
            return entities;
        }

        public virtual async Task<TEntity> GetByIdAsync(T id)
        {
            var entity = await Data.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await Data.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual Task UpdateAsync(TEntity entity)
        {

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.UpdatedAt = DateTime.UtcNow;
            Data.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(T id)
        {
            var entity = new TEntity();
            entity.Id = id;
            Data.Remove(entity);
            Context.SaveChanges();
            return Task.CompletedTask;
        }
    }

    //public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    //{
    //    protected RepositoryContext _repositoryContext { get; set; }

    //    public RepositoryBase(RepositoryContext repositoryContext)
    //    {
    //        _repositoryContext = repositoryContext;
    //    }

    //    public IQueryable<T> GetAll()
    //    {
    //        return _repositoryContext.Set<T>().AsNoTracking();
    //    }

    //    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
    //    {
    //        return _repositoryContext.Set<T>().Where(expression).AsNoTracking();
    //    }

    //    public void Add(T entity)
    //    {
    //        _repositoryContext.Set<T>().Add(entity);
    //    }

    //    public void Update(T entity)
    //    {
    //        _repositoryContext.Set<T>().Update(entity);
    //    }

    //    public void Delete(T entity)
    //    {
    //        _repositoryContext.Set<T>().Remove(entity);
    //    }

    //    public async Task SaveAsync()
    //    {
    //        await _repositoryContext.SaveChangesAsync();
    //    }
    //}


}
