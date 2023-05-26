using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBizTrip.Domain.Model;

namespace WBizTrip.Services.Abstractions
{
    public interface ITokenService
    {
        public JwtSecurityToken GenerateToken(User user);
    }
}
