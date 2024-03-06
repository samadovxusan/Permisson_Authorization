using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Application.Dto_s
{
    public class TokenDto
    {
        public string? AccessToken {  get; set; }
        public string? RefreshToken {  get; set; }
        public DateTime? RefreshTokenExpires { get; set; } = DateTime.UtcNow;

    }
}
