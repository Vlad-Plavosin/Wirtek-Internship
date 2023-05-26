using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBizTrip.Domain.DTO;
using WBizTrip.Domain.Model;

namespace WBizTrip.Services.Abstractions
{
    public interface IUserService
    {
        public void CreateUser(User user);
        public void UpdateUser(int id, User user);
        public void DeleteUser(int Id);
        public IEnumerable<UserDto> GetUsers();
        public User GetUserById(int id);

        public Task<string> Login(User _userData);
        public Task<User> GetUserByEmail(string email);
    }
}
