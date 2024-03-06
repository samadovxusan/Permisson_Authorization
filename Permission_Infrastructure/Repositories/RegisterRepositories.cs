using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;
using Permission_Domen.Entityes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Infrastructure.Repositories
{
    public class RegisterRepositories : IRegisterRepositories
    {
        private readonly AppDbContext _appDbContext;
        public RegisterRepositories(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Permission_Domen.Entityes.User> Registration(RegisterDTO registerDTO)
        {

            var refrashtoken = Guid.NewGuid().ToString();

            var newuser = new User();
            newuser.Name = registerDTO.Name;
            newuser.Email = registerDTO.Email;
            newuser.Password = registerDTO.Password;
            newuser.ERole = registerDTO.ERole;
            newuser.Price = registerDTO.Price;
            newuser.CreatedAt = DateTime.UtcNow;
            newuser.RefreshToken = refrashtoken;
            newuser.Expridate = DateTime.UtcNow.AddDays(7);

            await _appDbContext.AddAsync(newuser);
            await _appDbContext.SaveChangesAsync();
            return newuser;
        }
    }
}
