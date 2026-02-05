using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Perisistance.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Perisistance.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository <TEntity, TKey>  where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext dbContext;

        public GenericRepository(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Add(TEntity entity)
        {
           await dbContext.Set<TEntity>().AddAsync(entity);
        }

        public Task<int> countAsync(ISpecifications<TEntity, TKey> specifications)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
          return await dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> specifications)
        {
            var Query=SpecificationsEvaluator.CreateQuery(dbContext.Set<TEntity>(),specifications);
            return await Query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
          return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> specifications)
        {
            var Query=SpecificationsEvaluator.CreateQuery(dbContext.Set<TEntity>(), specifications);
            return await Query.FirstOrDefaultAsync();
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }
    }
}
