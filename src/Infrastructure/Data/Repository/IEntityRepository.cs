using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IEntityRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task FindAndUpdate(Expression<Func<TEntity, bool>> filterDefinition, Action<TEntity> updateDefinition);
        Task Remove(TEntity entity);
    }
}