using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entity);

		void Update(T entity);
        void Delete(T entity);
        Task<TResult> GetByIdAsync<TResult>(object id, Expression<Func<T, TResult>> selector);
        Task<IEnumerable<TResult>> GetAllWithSelectorAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>>? Predecate = null);
        Task<IEnumerable<TResult>> GetAllWithSelectorAndPaginationAsync<TResult>(
            Expression<Func<T, TResult>> selector,
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? Predecate = null
            );

        Task<List<T>> GetAllWithFilterAsync(Expression<Func<T, bool>> Predecate);
        Task<T> GetByIdFirstOrDefaultAsync(Expression<Func<T, bool>> Predecate);
        Task<TResult?> FirstOrDefaultWithSelectorAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> Predecate);
        //Task softDeleteAsync(Expression<Func<T, bool>> Predecate, Func<T, bool> propertyToSet);
    }
}
