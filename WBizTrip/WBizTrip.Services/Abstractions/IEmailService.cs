using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBizTrip.Domain.DTO;

namespace WBizTrip.Services.Abstractions
{
    public interface IEmailService
    {
        public void SendGroupEmail(EmailDto request);
    }
}
