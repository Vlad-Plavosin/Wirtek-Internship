using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBizTrip.Domain.Enums;

namespace WBizTrip.Domain.DTO
{
    public class UserDto
    {
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public UserRole Role { get; set; }
    }
}
