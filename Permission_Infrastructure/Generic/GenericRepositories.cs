using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Permission_Application.Abstractions.Generic;
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
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> dbSet;
        public GenericRepositories(AppDbContext app)
        {
            _appDbContext = app;
            dbSet = _appDbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                var entry = await dbSet.AddAsync(entity);
               await _appDbContext.SaveChangesAsync();
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
                await _appDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
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

        public async Task<T> GetByAny(Expression<Func<T, bool>> expression)
        {


            try
            {
                var result = await dbSet.FirstOrDefaultAsync(expression);
                return  result;
            }
            catch (Exception ex)
            {
                throw; ;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var entry = dbSet.Update(entity);
                await _appDbContext.SaveChangesAsync();
                return entry.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
