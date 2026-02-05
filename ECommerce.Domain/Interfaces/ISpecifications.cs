using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Interfaces
{
    public interface ISpecifications<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        public ICollection<Expression<Func<TEntity,object>>> IncludeExepressions { get;}
        Expression<Func<TEntity,bool>> Criteria { get;}
        Expression<Func<TEntity,object>> OrderBy { get;}
        Expression<Func<TEntity, object>> OrderByDesc { get; }
        int skip { get;}
        int take { get;}
        bool isPaginated { get;}

    }
}
