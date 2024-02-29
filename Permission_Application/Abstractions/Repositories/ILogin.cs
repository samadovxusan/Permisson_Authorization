using Permission_Application.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Application.Abstractions.Repositories
{
    public interface ILogin
    {
        Task<string> Loogin(LoginDTO loginDTO);
    }
}
