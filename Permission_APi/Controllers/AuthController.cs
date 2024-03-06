using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;
using Permission_Infrastructure;

namespace Permission_APi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly ILoginRepositories _login;
        private readonly IRegisterRepositories _register;
        private readonly AppDbContext _appDbContext;
        public AuthController(ILoginRepositories login, IRegisterRepositories register,AppDbContext appDbContext)
        {
            _login = login;
            _register = register;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO register) => Ok(await _register.Registration(register));
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO) => Ok(await _login.Loogin(loginDTO));

        [HttpPost]
        public async Task<IActionResult> Refrashtoke(TokenDto tokenDto)
        {



            var acses = await _appDbContext.Users.FirstOrDefaultAsync(x => x.RefreshToken == tokenDto.RefreshToken);

            if(acses == null)
            {

            }
        }



    }
}
