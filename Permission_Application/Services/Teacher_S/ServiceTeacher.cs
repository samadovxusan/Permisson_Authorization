using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;
using Permission_Domen.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Application.Services.Teacher_S
{
    public class ServiceTeacher : IServiceTeacher
    {
        private readonly ITeacherRepositories _teacherRepositories;

        public ServiceTeacher(ITeacherRepositories teacherRepositories) => _teacherRepositories = teacherRepositories;

        public async Task<Teacher> CreateAsync(TeacherDto entity)
        {
            var newtech = new Teacher();
            newtech.Name = entity.Name;
            newtech.Description = entity.Description;
            newtech.Price = entity.Price;
            newtech.Experience = entity.Experience;
            newtech.CreatedAt = DateTime.UtcNow;

            await _teacherRepositories.CreateAsync(newtech);
            return newtech;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Teacher, bool>> expression)
        {
            return await _teacherRepositories.DeleteAsync(expression);
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            var find = await _teacherRepositories.GetAllAsync();
            if(find != null)
            {
                return find;
            }
            throw new NotImplementedException();
        }

        public async Task<Teacher> GetAsync(Expression<Func<Teacher, bool>> expression)
        {
            var find = await _teacherRepositories.GetAsync(expression);
            if(find is null)
            {
                throw new NotImplementedException();
            }
            return find;
        }

        public async Task<Teacher> GetById(int Id)
        {
            var find = await _teacherRepositories.GetByAny(x => x.Id == Id);
            return find;
        }

        public async Task<Teacher> UpdateAsync(int id, TeacherDto entity)
        {
            var find = await _teacherRepositories.GetByAny(X => X.Id == id);
            find.Name = entity.Name;
            find.Description = entity.Description;
            find.Price = entity.Price;
            find.Experience = entity.Experience;
            find.UpdatedAt = DateTime.UtcNow;

            return await _teacherRepositories.UpdateAsync(find);
            
        }
    }
}
