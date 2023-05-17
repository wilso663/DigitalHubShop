using Core.Models;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseModel
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if(spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDescending != null) 
            { 
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if(spec.isPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            //Aggregate navigation variables into IQueryable
            query = spec.Includes.Aggregate(query, (curr, include) => curr.Include(include));

            return query;
        }
    }
}
