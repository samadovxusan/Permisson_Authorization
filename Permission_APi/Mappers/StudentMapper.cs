using AutoMapper;
using Permission_Application.Dto_s;
using Permission_Domen.Entityes;

namespace Permission_APi.Mappers
{
    public class StudentMapper:Profile
    {
        public StudentMapper()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
