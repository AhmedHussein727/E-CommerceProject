using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using ECommerce.Perisistance.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Perisistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext dbContext;
        private readonly Dictionary<Type, object> rebositories=[];

        public UnitOfWork(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var EntityType=typeof(TEntity);
            if(rebositories.TryGetValue(EntityType, out object? rebository))
            {
                return (IGenericRepository<TEntity,TKey >) rebository;
            }

            var newRebo=new GenericRepository<TEntity,TKey>(dbContext);
            rebositories[EntityType]=newRebo;
            return newRebo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
