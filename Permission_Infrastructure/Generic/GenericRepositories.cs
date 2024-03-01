using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Permission_Application.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Infrastructure.Generic
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T : class
    {
        public DbSet<T> dbSet;
        private readonly ILogger logger;
        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                var entry = await dbSet.AddAsync(entity);

                return entry.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entity = await dbSet.FirstOrDefaultAsync(expression);

                if (entity is null)
                    return false;

                dbSet.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            try
            {
                return expression is null ? dbSet : dbSet.Where(expression);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entity = await dbSet.FirstOrDefaultAsync(expression);
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var entry = dbSet.Update(entity);

                return entry.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
