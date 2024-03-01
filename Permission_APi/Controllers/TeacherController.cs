using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permission_Application.Dto_s;
using Permission_Application.Services.Teacher_S;
using Permission_Domen.Entityes;
using System.Linq.Expressions;

namespace Permission_APi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IServiceTeacher _serviceTeacher;

        public TeacherController(IServiceTeacher serviceTeacher) => _serviceTeacher = serviceTeacher;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _serviceTeacher.GetAllAsync());
        [HttpGet]
        public async Task<IActionResult> GetById(int id) => Ok(await _serviceTeacher.GetById(id));
        [HttpPost]
        public async Task<IActionResult> Create(TeacherDto teacherDto) => Ok(await _serviceTeacher.CreateAsync(teacherDto));
        [HttpPut]
        public async Task<IActionResult> Update(int id, TeacherDto teacherDto) => Ok(await _serviceTeacher.UpdateAsync(id,teacherDto));
        [HttpDelete]
        public async Task<IActionResult> Delete(Expression<Func<Teacher, bool>> expression) => Ok(await _serviceTeacher.DeleteAsync(expression));


    }
}
