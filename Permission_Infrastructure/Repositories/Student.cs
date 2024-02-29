using Microsoft.EntityFrameworkCore;
using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;
using Permission_Domen.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Infrastructure.Repositories
{
    public class Student : IStudent
    {
        private readonly AppDbContext _appDbContext;
        public Student(AppDbContext appDbContextq) => _appDbContext = appDbContextq;
        public async Task<Permission_Domen.Entityes.Student> Create(StudentDTO studentDTO)
        {
            var stu = new Permission_Domen.Entityes.Student();
            stu.Phone_Number = studentDTO.Phone_Number;
            stu.Name = studentDTO.Name;
            stu.UserID = studentDTO.UserID;
            stu.Email = studentDTO.Email;
            stu.CreatedAt = DateTime.UtcNow;

            _appDbContext.Students.Add(stu);
            await _appDbContext.SaveChangesAsync();
            return stu;
        }

        public async Task<Permission_Domen.Entityes.Student> Delete(int id)
        {
            var result = await _appDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if(result == null)
            {
                return null;
            }
            _appDbContext.Students.Remove(result);
            await _appDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<List<Permission_Domen.Entityes.Student>> GetAll()
        {

            return await _appDbContext.Students.ToListAsync();

        }

        public async Task<Permission_Domen.Entityes.Student> GetById(int id)
        {
            return await _appDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Permission_Domen.Entityes.Student> Update(int id, StudentDTO studentDTO)
        {
            var result = await _appDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            var stu = new Permission_Domen.Entityes.Student();
            result.Phone_Number = studentDTO.Phone_Number;
            result.Name = studentDTO.Name;
            result.UserID = studentDTO.UserID;
            result.Email = studentDTO.Email;
            result.CreatedAt = DateTime.UtcNow;

            _appDbContext.Students.Update(result);
            await _appDbContext.SaveChangesAsync();
            return result;

        }
    }
}
