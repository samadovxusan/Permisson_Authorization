using Permission_Domen.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Domen.Entityes
{
    public class Course
    {
        public ProgrammerLanguages ProgrammerLanguages { get; set; }
        public Teacher? Teacherid { get; set; }
        public Student? student { get; set; }
        public DateTime StartCourse { get; set; }
        public DateTime EndCourse { get; set; }
        public DateTime ClassStartTime { get; set; }


    }
}
