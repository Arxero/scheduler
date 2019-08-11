using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<TEntity, T>
        where TEntity : Entity<T>
        where T: IEquatable<T>
    {
        Task<PagedData<TEntity>> QueryAsync(Paging paging = null);
        Task<TEntity> GetByIdAsync(T id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task RemoveAsync(T entity);

    }
}
