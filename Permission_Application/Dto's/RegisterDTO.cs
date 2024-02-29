using Permission_Domen.Common;
using Permission_Domen.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Application.Dto_s
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ERole ERole { get; set; }
        public Decimal Price { get; set; }

    }
}
