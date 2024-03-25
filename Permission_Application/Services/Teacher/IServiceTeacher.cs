using Permission_Application.Abstractions.Generic;
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
    public interface IServiceTeacher
    {
        public Task<IEnumerable<Teacher>> GetAllAsync();
        public Task<Teacher> GetAsync(Expression<Func<Teacher, bool>> expression);
        public Task<Teacher> CreateAsync(TeacherDto entity);
        public Task<Teacher> UpdateAsync(int id ,TeacherDto entity);
        public Task<bool> DeleteAsync(Expression<Func<Teacher, bool>> expression);
        public Task<Teacher>GetById(int Id);;
    }
}
