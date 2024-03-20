using AutoMapper;
using Permission_Application.Dto_s;

namespace Permission_APi.Mappers
{
    public class TeacherMapper:Profile
    {
        public TeacherMapper()
        {
            CreateMap<TeacherMapper, TeacherDto>().ReverseMap();
            CreateMap<TeacherMapper, TeacherDto>().ReverseMap(); 
        }
    }
}
