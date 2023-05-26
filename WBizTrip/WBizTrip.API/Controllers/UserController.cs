using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WBizTrip.Domain.Utils;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Enums;
using WBizTrip.Domain.Model;
using WBizTrip.Services.Abstractions;
using WBizTrip.Services.Exceptions;

namespace WBizTrip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            try
            {
                return Ok(_userService.GetUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                return Ok(_userService.GetUserById(id));
            }
            catch (UserNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            var user = new User()
            {
                Name = userDto.Name,
                Password = userDto.Password,
                Email = userDto.Email,
                Role = userDto.Role,
            };
            try
            {
                _userService.CreateUser(user);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
           
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto userDto)
        {
            var user = new User()
            {
                Name = userDto.Name,
                Password = userDto.Password,
                Role = userDto.Role,
            };

            try
            {
                _userService.UpdateUser(id, user);
                return Ok();
            }
            catch (UserNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok();
            }
            catch (UserNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> GenerateToken(User _userData) 
        {
            try
            {
                var token = await _userService.Login(_userData);
                return Ok(token);
            }
            catch (InvalidCredentialsException exception)
            {
                return exception.Message;
            }
            catch (NoCredentialsException exception)
            {
                return exception.Message;
            }
        }
    }
}
