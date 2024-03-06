using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;
using Permission_Infrastructure.JWT_Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Infrastructure.Repositories
{
    public class LoginRepositories : ILoginRepositories
    {
        private readonly IConfiguration _configuration;

        private readonly AppDbContext _dbContext;
        public LoginRepositories(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<TokenDto> Loogin(LoginDTO user)
        {

            var newUser = await _dbContext.
                Users.FirstOrDefaultAsync(x=> x.Password == user.Password && x.Email == user.Email);

            var jwtToken = new GeneretTokenServies(_configuration);
            var result = await jwtToken.GenerateToken(newUser);
            return new TokenDto() {
                AccessToken = result,
                RefreshToken = newUser.RefreshToken,
                RefreshTokenExpires = DateTime.UtcNow.AddDays(7)
            };
            }
    }
}
