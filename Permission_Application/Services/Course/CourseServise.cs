using Permission_Application.Abstractions.Generic;
using Permission_Application.Abstractions.Repositories;
using Permission_Domen.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Application.Services.Course
{
    public class CourseServise : ICourseServise
    {
        private readonly ICourseRepositories _courseRepositories;

        public CourseServise(ICourseRepositories courseRepositories)
        {
            _courseRepositories = courseRepositories;
        }

        public async Task<Permission_Domen.Entityes.Course> CreateAsync(Permission_Domen.Entityes.Course entity)
        {
            return await _courseRepositories.CreateAsync(entity);

        }

        public async Task<bool> DeleteAsync(Expression<Func<Permission_Domen.Entityes.Course, bool>> expression)
        {
            return await _courseRepositories.DeleteAsync(expression);
        }

        public async Task<IEnumerable<Permission_Domen.Entityes.Course>> GetAllAsync()
        {
            return await _courseRepositories.GetAllAsync();
        }

        public async Task<Permission_Domen.Entityes.Course> GetAsync(Expression<Func<Permission_Domen.Entityes.Course, bool>> expression)
        {
            return await _courseRepositories.GetAsync(expression);
        }

        public Task<Permission_Domen.Entityes.Course> GetByAny(Expression<Func<Permission_Domen.Entityes.Course, bool>> expression)
        {
            return _courseRepositories.GetByAny(expression);
        }

        public async Task<Permission_Domen.Entityes.Course> UpdateAsync(Permission_Domen.Entityes.Course entity)
        {
            return await _courseRepositories.UpdateAsync(entity);
        }
    }
}
