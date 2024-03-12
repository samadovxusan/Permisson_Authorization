using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Permission_Application.Abstractions.Repositories;
using Permission_Application.Dto_s;
using Permission_Domen.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Infrastructure.Repositories
{
    public class StudentRepositories : IStudentRepositories
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _autoMapper;
        private readonly ILogger<Student> _logger;

        public StudentRepositories(IMapper autoMapper , AppDbContext appDbContext,ILogger<Student> logger)
        {
            _autoMapper = autoMapper;
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<Permission_Domen.Entityes.Student> Create(StudentDTO studentDTO)
        {
            try
            {
                var stu = _autoMapper.Map<Student>(studentDTO);
                stu.CreatedAt = DateTime.UtcNow;
                _appDbContext.Students.Add(stu);
                await _appDbContext.SaveChangesAsync();
                _logger.LogInformation("ok");

                return stu;

            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
           
        }

        public async Task<Permission_Domen.Entityes.Student> Delete(int id)
        {
            try
            {
                var result = await _appDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

                if(result != null)
                {
                    result.IsDeleted = true;
                    _appDbContext.Update(result);
                    await _appDbContext.SaveChangesAsync();
                    _logger.LogInformation("Ok");
                    return result;
                }
                return null;
              
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
          
        }

        public async Task<List<Permission_Domen.Entityes.Student>> GetAll()
        {
            try
            {
                _logger.LogInformation("Test Logs");
                return await _appDbContext.Students
                .ToListAsync();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }

        public async Task<Permission_Domen.Entityes.Student> GetById(int id)
        {
            try
            {

                _logger.LogInformation("ok");
                return await _appDbContext.Students
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.Id == id);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }

        public async Task<Student> Update(int id, StudentDTO studentDTO)
        {

            try
            {
                var result = await _appDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
                //var stu = new Permission_Domen.Entityes.Student();
                //result.Phone_Number = studentDTO.Phone_Number;
                //result.Name = studentDTO.Name;
                //result.UserID = studentDTO.UserID;
                //result.Email = studentDTO.Email;
                //result.CreatedAt = DateTime.UtcNow;

                var resultDto = _autoMapper.Map<Student>(studentDTO);

                resultDto.Id = result.Id;


                

                _appDbContext.Students.Update(resultDto);
                await _appDbContext.SaveChangesAsync();
                _logger.LogInformation("ok");
                return resultDto;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

          

        }
    }
}
