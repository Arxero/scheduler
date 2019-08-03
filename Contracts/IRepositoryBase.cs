using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    //public interface IRepositoryBase<TEntity>
    //{
    //    IQueryable<TEntity> GetAll();
    //    IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);
    //    void Add(TEntity entity);
    //    void Update(TEntity entity);
    //    void Delete(TEntity entity);
    //    Task SaveAsync();
    //}

    public interface IRepositoryBase<TEntity, T>
        where TEntity : Entity<T>
        where T: IEquatable<T>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(T id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(T entity);

    }
}
