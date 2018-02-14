using Pasarela.Core.Services.RequestProvider;
using System;
using System.Threading.Tasks;
using Pasarela.Core.Models.User;
using Pasarela.Core.Models.Common;

namespace Pasarela.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRequestProvider _requestProvider;

        public UserService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        //public async Task<UserInfo> GetUserInfoAsync(string authToken)
        //{

        //    UriBuilder builder = new UriBuilder(GlobalSetting.Instance.UserInfoEndpoint);

        //    string uri = builder.ToString();

        //    var userInfo =
        //        await _requestProvider.GetAsync<UserInfo>(uri, authToken);

        //    return userInfo;

        //}

        public async Task<UserInfo> GetUserInfoAsync(string username, string password)
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.UsuarioEndPoint,
            string.Format(Constants.Parameters.USERNAME+ "/{0}" + Constants.Parameters.PASSWORD + "/{1}", username,password));
            var user = await _requestProvider.GetAsync<UserInfo>(uri);
            return user;
        }

        public async Task<Models.User.User> SaveUserAsync(Models.User.User _saveUser)
        {
            string uri = GlobalSetting.Instance.UsuarioEndPoint;
            var saveUser = await _requestProvider.PostAsync<Models.User.User>(uri, _saveUser).ConfigureAwait(false);
            return saveUser;
        }

        public async Task<bool> UpdatePasswordAsync(int id, ChangePassword _change)
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.UsuarioEndPoint,
            string.Format("/{0}" + "/UpdatePassword", id));
            var changePassword = await _requestProvider.PutAsync<ChangePassword>(uri, _change).ConfigureAwait(false);
            return changePassword;
        }

        public async Task<bool> UpdateUserAsync(int id, UserInfo _updateUser)
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.UsuarioEndPoint,
            string.Format("/{0}" + "/UpdateUsuario", id));
            var updateUser = await _requestProvider.PutAsync<Models.User.UserInfo>(uri, _updateUser).ConfigureAwait(false);
            return updateUser;
        }
    }
}