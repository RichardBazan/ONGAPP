﻿using Pasarela.Core.Services.RequestProvider;
using System;
using System.Threading.Tasks;
using Pasarela.Core.Models.User;

namespace Pasarela.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRequestProvider _requestProvider;

        public UserService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<UserInfo> GetUserInfoAsync(string authToken)
        {

            UriBuilder builder = new UriBuilder(GlobalSetting.Instance.UserInfoEndpoint);

            string uri = builder.ToString();

            var userInfo =
                await _requestProvider.GetAsync<UserInfo>(uri, authToken);

            return userInfo;

        }

        public async Task<Models.User.User> SaveUserAsync(Models.User.User _saveUser)
        {
            string uri = GlobalSetting.Instance.UsuarioEndPoint;
            var saveUser = await _requestProvider.PostAsync<Models.User.User>(uri, _saveUser).ConfigureAwait(false);
            return saveUser;
        }
    }
}