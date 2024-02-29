using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;
using Permission_Domen.Entityes;

namespace Permission_APi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        public StudentController(IStudent student) => _student = student;

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAll() => Ok(await _student.GetAll());

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> Get(int id) => Ok(await _student.GetById(id));

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(StudentDTO student) => Ok(await _student.Create(student));

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, StudentDTO student) => Ok(await _student.Update(id,student));

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) => Ok(await _student.Delete(id));
    }
}
