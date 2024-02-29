using Permission_Application.Dto_s;
using Permission_Domen.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Application.Abstractions.Repositories
{
    public interface IRegister
    {
        Task<User> Registration(RegisterDTO registerDTO); 
    }
}
