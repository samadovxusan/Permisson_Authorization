using Permission_Application.Abstractions.Repositories;
using Permission_Domen.Entityes;
using Permission_Infrastructure.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Infrastructure.Repositories
{
    public class CourseRepositories : GenericRepositories<Course>,ICourseRepositories
    {
        public CourseRepositories(AppDbContext app) : base(app)
        {

        }
    }
}
