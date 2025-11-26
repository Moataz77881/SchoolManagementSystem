using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Interfaces.Repositories;
using SchoolManagementSystem.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Implementation.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<List<T>> GetAllWithFilterAsync(Expression<Func<T,bool>> Predecate)
        {
            return await _dbSet.Where(Predecate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

		public async Task AddRangeAsync(List<T> entity)
		{
			await _dbSet.AddRangeAsync(entity);
		}

		public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<TResult> GetByIdAsync<TResult>(object id, Expression<Func<T, TResult>> selector)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return default;

            
            return _dbSet
                .Where(e => e == entity)
                .Select(selector)
                .FirstOrDefault()!;
        }

        public async Task<IEnumerable<TResult>> GetAllWithSelectorAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>>? Predecate = null)
        {
            if(Predecate is not null)
                 return await _dbSet
                    .Where(Predecate)
                    .Select(selector)
                    .ToListAsync();

            return await _dbSet
					.Select(selector)
					.ToListAsync();

		}
        public async Task<IEnumerable<TResult>> GetAllWithSelectorAndPaginationAsync<TResult>(
            Expression<Func<T, TResult>> selector,
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? Predecate = null
            )
        {
            IQueryable<T> query = _dbSet;

            // Apply predicate
            if (Predecate is not null)
                query = query.Where(Predecate);

            // Apply select
            var selectedQuery = query.Select(selector);

            // Apply pagination
            if (pageNumber > 0 && pageSize > 0)
            {
                selectedQuery = selectedQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);
            }

            return await selectedQuery.ToListAsync();

        }

        //public async Task softDeleteAsync(Expression<Func<T, bool>> Predecate, Func<T, bool> propertyToSet)
        //{
        //    await _dbSet.Where(Predecate).ExecuteUpdateAsync(s => s.SetProperty(x => propertyToSet, _ => true));
        //}
    }
}
