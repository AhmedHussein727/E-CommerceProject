using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Perisistance
{
    internal static class SpecificationsEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> EntryPoint,
            ISpecifications<TEntity, TKey> Specifications)where TEntity : BaseEntity<TKey>
        {
            var Query = EntryPoint;
            if(Specifications is not  null)
            {
                if(Specifications.Criteria is not null)
                {
                    Query = Query.Where(Specifications.Criteria);
                }
                if(Specifications.IncludeExepressions is  not null&& Specifications.IncludeExepressions.Any())
                {
                    //foreach(var IncludeExep in specifications.IncludeExepressions)
                    //{
                    //    Query=Query.Include(IncludeExep);
                    //}
                    Query = Specifications.IncludeExepressions.Aggregate(Query
                        , (CurrentQuery, IncludeExp) => CurrentQuery.Include(IncludeExp));
                }
                if( Specifications.OrderBy is not null)
                    Query = Query.OrderBy(Specifications.OrderBy);

                if (Specifications.OrderByDesc is not null)
                    Query = Query.OrderByDescending(Specifications.OrderByDesc);
                if (Specifications.isPaginated is not false)
                    Query = Query.Skip(Specifications.skip).Take(Specifications.take);
            }
            return Query;
        }
    }
}
