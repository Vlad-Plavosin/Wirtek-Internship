using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WBizTrip.API.Data;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;
using WBizTrip.Services.Abstractions;
using WBizTrip.Services.Exceptions;

namespace WBizTrip.Services
{
    public class UserService : IUserService
    {
        private readonly WBizTripDbContext _dbContext;
        public IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public UserService(WBizTripDbContext dbContext, IConfiguration configuration, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _tokenService = tokenService;
        }
        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int Id)
        {
            var user = _dbContext.Users.Find(Id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new UserNotFoundException("Cannot delete! The user was not found.");
            }
        }

        public User GetUserById(int id)
        {
            var user = _dbContext.Users.Find(id);
            if(user != null)
                return user;
            else
            {
                throw new UserNotFoundException("The user was not found");
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        } 

        public IEnumerable<UserDto> GetUsers()
        {
            var users = _dbContext.Users.ToList();
            var usersDto = users.Select(user => new UserDto()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role

            }) ;
            return usersDto.ToList();
        }

        private async Task<User> GetUser(string email, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public void UpdateUser(int id, User user)
        {
            var userToUpdate = _dbContext.Users.Find(id); 
            if(userToUpdate != null)
            {
                userToUpdate.Name = user.Name;
                userToUpdate.Role = user.Role;
                userToUpdate.TeamLeader = user.TeamLeader;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new UserNotFoundException("Cannot update! The user was not found.");
            }
        }

        public async Task<string> Login(User _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Email, _userData.Password);

                if (user != null)
                {
                    var token = _tokenService.GenerateToken(user);
                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                else
                {
                    throw new InvalidCredentialsException("Invalid credentials!");
                }
            }
            else
            {
                throw new NoCredentialsException("No credentials recieved!");
            }
        }

    }
}
