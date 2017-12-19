using Pasarela.Core.Models.User;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.User
{
    public interface IUserService
    {
        Task<UserInfo> GetUserInfoAsync(string username, string password);

        Task<Models.User.User> SaveUserAsync(Models.User.User _saveUser);
    }
}
