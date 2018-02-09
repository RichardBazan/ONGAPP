using System;
using Pasarela.Core.Models.User;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.User
{
    public class UserMockService : IUserService
    {

        public Task<UserInfo> GetUserInfoAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Models.User.User> SaveUserAsync(Models.User.User _saveUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePasswordAsync(int id, ChangePassword _change)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(int id, UserInfo _saveUser)
        {
            throw new NotImplementedException();
        }
    }
}