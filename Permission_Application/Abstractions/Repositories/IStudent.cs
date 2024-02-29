using Permission_Application.Dto_s;
using Permission_Domen.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Application.Abstractions.Repositories
{
    public interface IStudent
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<Student> Create(StudentDTO studentDTO);
        Task<Student> Update(int id, StudentDTO studentDTO);
        Task<Student> Delete(int id);
    }
}
