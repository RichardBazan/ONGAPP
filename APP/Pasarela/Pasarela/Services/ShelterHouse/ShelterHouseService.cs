using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.ShelterHouse;
using Pasarela.Core.Models.Common;
using Pasarela.Core.Services.RequestProvider;

namespace Pasarela.Core.Services.ShelterHouse
{
    public class ShelterHouseService : IShelterHouseService
    {

        IRequestProvider _requestProvider;

        public ShelterHouseService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<List<Models.ShelterHouse.ShelterHouse>> GetShelterHouseAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Models.ShelterHouse.ShelterHouse>> GetAllShelterHouseAsync()
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.CasaRefugioEndPoint,
            string.Format(Constants.MethodsService.METHOD_ALL_SHELTERHOUSE));
            var listShelterHouse = await _requestProvider.GetAsync<List<Models.ShelterHouse.ShelterHouse>>(uri);
            return listShelterHouse;
        }

        public async Task<List<Models.ShelterHouse.ShelterHouse>> GetShelterHouseByUserAsync(int userId)
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.CasaRefugioEndPoint,
            string.Format("/{0}" + Constants.MethodsService.METHOD_SHELTERHOUSE_USER,userId));
            var listShelterHouse = await _requestProvider.GetAsync<List<Models.ShelterHouse.ShelterHouse>>(uri);
            return listShelterHouse;
        }

        public async Task<SaveShelterHouse> SaveShelterHouseAsync(SaveShelterHouse _saveShelterHouse)
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.CasaRefugioEndPoint,
            string.Format(Constants.MethodsService.METHOD_SAVE_SHELTERHOUSE));
            var saveShelterHouse = await _requestProvider.PostAsync<SaveShelterHouse>(uri, _saveShelterHouse).ConfigureAwait(false);
            return saveShelterHouse;
        }

    }
}
