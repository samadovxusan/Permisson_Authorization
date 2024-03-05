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
    public class CourseRepositories : ICourseRepositories
    {
        public Task<Permission_Domen.Entityes.Course> CreateAsync(Permission_Domen.Entityes.Course entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<Permission_Domen.Entityes.Course, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Permission_Domen.Entityes.Course>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Permission_Domen.Entityes.Course> GetAsync(Expression<Func<Permission_Domen.Entityes.Course, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Permission_Domen.Entityes.Course> GetByAny(Expression<Func<Permission_Domen.Entityes.Course, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Permission_Domen.Entityes.Course> UpdateAsync(Permission_Domen.Entityes.Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
