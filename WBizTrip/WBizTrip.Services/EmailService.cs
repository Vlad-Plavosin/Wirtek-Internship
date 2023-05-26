using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBizTrip.API.Data;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;
using WBizTrip.Services.Abstractions;

namespace WBizTrip.Services
{
    public class EmailService : IEmailService
    {
        private readonly WBizTripDbContext _dbContext;
        public EmailService(WBizTripDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SendGroupEmail(EmailDto request)
        {
            var email = new MimeMessage();
            var toEmails = _dbContext.Users.Where(user => user.Role == request.Receivers);
            email.From.Add(MailboxAddress.Parse("dreamteam.wirtek@gmail.com"));
            foreach(var user in toEmails)
                email.To.Add(MailboxAddress.Parse(user.Email));
            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("dreamteam.wirtek@gmail.com", "wcqzsygzwfmpomfg");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
