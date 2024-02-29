using Permission_Domen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Domen.Entityes
{
    public class Student:AuditTable
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }


    }
}
