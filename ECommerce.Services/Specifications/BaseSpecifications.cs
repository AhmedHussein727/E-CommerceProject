using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services.Specifications
{
    public abstract class BaseSpecifications<TEntity,TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected BaseSpecifications(Expression<Func<TEntity,bool>>criteriaExep)
        {
            Criteria=criteriaExep;
        }









        #region Filtration
        public Expression<Func<TEntity, bool>> Criteria { get; }
        #endregion


        #region Pagination
        public int skip { get; private set; }

        public int take { get; private set; }

        public bool isPaginated { get; private set; }

        protected void ApplyPagination(int PageSize,int PageIndex)
        {
            isPaginated = true;
            skip =PageSize*PageIndex-1;
            take = PageSize;

        }
        #endregion


        #region Including

        public ICollection<Expression<Func<TEntity, object>>> IncludeExepressions { get; } = [];
        protected void AddInclude(Expression<Func<TEntity, object>> includeExp)
        {
            IncludeExepressions.Add(includeExp);
        }
        #endregion


        #region Ordring
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDesc { get; private set; }
        protected void AddOrderBy(Expression<Func<TEntity, object>> OrderByExep)
        {
            OrderBy = OrderByExep;
        }
        protected void AddOrderByDesc(Expression<Func<TEntity, object>> OrderByDescExep)
        {
            OrderByDesc = OrderByDescExep;
        }
        #endregion
    }
}
