using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;

namespace Permission_APi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly ILoginRepositories _login;
        private readonly IRegisterRepositories _register;
        public AuthController(ILoginRepositories login, IRegisterRepositories register)
        {
            _login = login;
            _register = register;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO register) => Ok(await _register.Registration(register));
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO) => Ok(await _login.Loogin(loginDTO));
    }
}
