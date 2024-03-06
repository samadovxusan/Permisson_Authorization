using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;
using Permission_Infrastructure.JWT_Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
                RefreshTokenExpires = DateTime.UtcNow.AddDays(1)
            };
        }
        public async Task<TokenDto> ValidateToken(TokenDto tokenDto)
        {
            var tvp = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["JWT:Issuer"],
                ValidAudience = _configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
            };
            var tokenhandler = new JwtSecurityTokenHandler();
            var ClaimPrincple = tokenhandler.ValidateToken(tokenDto.AccessToken, tvp, out SecurityToken newtoken);
            var gmail =  ClaimPrincple.FindFirst(ClaimTypes.Email).Value;

            var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Email ==  gmail);

            if (user.Expridate > tokenDto.RefreshTokenExpires)
            {
                throw new Exception("Refresh Token Expired");
            }
            if( user.RefreshToken !=  tokenDto.RefreshToken)
            {
                throw new Exception("Refresh Invalid");

            }
            var jwtToken = new GeneretTokenServies(_configuration);

            var accsessToken =  await jwtToken.GenerateToken(user);
            return new TokenDto
            {
                AccessToken = accsessToken,
                RefreshToken = tokenDto.RefreshToken,
                RefreshTokenExpires = tokenDto.RefreshTokenExpires,
            };

        }




    }
}
