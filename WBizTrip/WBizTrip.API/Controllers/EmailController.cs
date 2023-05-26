using Microsoft.AspNetCore.Mvc;
using WBizTrip.Domain.DTO;
using WBizTrip.Services.Abstractions;

namespace WBizTrip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost("send-email")]
        public IActionResult SendGroupEmail([FromBody]EmailDto request)
        {
            try
            {
                _emailService.SendGroupEmail(request);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
