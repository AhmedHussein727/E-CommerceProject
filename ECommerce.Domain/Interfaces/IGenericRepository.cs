using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Interfaces
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>>GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity,TKey>Specifications);

        Task<TEntity?>GetByIdAsync(TKey id);
        Task<TEntity?> GetByIdAsync(ISpecifications<TEntity,TKey>specifications);

        Task Add(TEntity entity);

        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task<int> countAsync(ISpecifications<TEntity,TKey>specifications);
    }
    
}
