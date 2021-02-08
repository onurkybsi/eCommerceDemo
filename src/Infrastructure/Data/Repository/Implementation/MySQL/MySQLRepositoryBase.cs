// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;

// namespace Infrastructure.Data
// {
//     public abstract class MySQLRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : Entity
//     {
//         private DbContextWrapper _context;

//         public MySQLRepositoryBase(DbContextWrapper context)
//         {
//             _context = context;
//         }

//         public async Task Create(TEntity entity)
//         {
//             var addedEntity = _context.Entry(entity);
//             addedEntity.State = EntityState.Added;
//             await _context.SaveChangesAsync();
//         }

//         public async Task FindAndUpdate(Expression<Func<TEntity, bool>> filterDefinition, Action<TEntity> updateDefinition)
//         {
//             var updatedEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(filterDefinition);
//             updateDefinition(updatedEntity);
//             await _context.SaveChangesAsync();
//         }

//         public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
//             => await _context.Set<TEntity>().FirstOrDefaultAsync(filter);


//         public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
//             => await _context.Set<TEntity>().Where(filter).ToListAsync();


//         public async Task Remove(TEntity entity)
//         {
//             var deletedEntity = _context.Entry(entity);
//             deletedEntity.State = EntityState.Deleted;
//             await _context.SaveChangesAsync();
//         }

//         public async Task Update(TEntity entity)
//         {
//             var updatedEntity = _context.Entry(entity);
//             updatedEntity.State = EntityState.Modified;
//             await _context.SaveChangesAsync();
//         }
//     }
// }