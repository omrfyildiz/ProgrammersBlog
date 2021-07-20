using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new() //to get filter 'T'
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        //To be able to filter the results we give the name to the expression "predicate"
        //Second expression is to get the first expression's other properties.

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, Object>>[] includeProperties);
        //Predicate is null because we would want to get all properties.

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        //For example, you would like to examine "any" user or article
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
