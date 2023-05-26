using Microsoft.AspNetCore.Authorization;

namespace WBizTrip.Domain.Utils
{
   
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizeEnumAttribute : AuthorizeAttribute
        {
            public AuthorizeEnumAttribute(params object[] roles)
            {
                //  If the roles array doesn´t contain an enum
                if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
                    throw new ArgumentException("This role is not a valid one.");

                this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
          
            }
        }
    }

