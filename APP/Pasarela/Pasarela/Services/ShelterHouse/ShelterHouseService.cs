using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.ShelterHouse;
using Pasarela.Core.Models.Common;
using Pasarela.Core.Services.RequestProvider;
using Pasarela.Core.Models.PhotoShelterHouse;

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
            string uri = GlobalSetting.Instance.CasaRefugioEndPoint;
            //string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.CasaRefugioEndPoint,
            //string.Format(Constants.MethodsService.METHOD_SHELTERHOUSE));
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
            string uri = GlobalSetting.Instance.CasaRefugioEndPoint;
            var saveShelterHouse = await _requestProvider.PostAsync<SaveShelterHouse>(uri, _saveShelterHouse).ConfigureAwait(false);
            return saveShelterHouse;
        }

        public async Task<List<SavePhotoShelterHouse>> SavePhotoShelterHouseAsync(List<SavePhotoShelterHouse> _savePhotoShelterHouse)
        {
            string uri = GlobalSetting.Instance.FotoCasaRefugioEndPoint;
            foreach (var item in _savePhotoShelterHouse)
            {
                var savePhotoShelterHouse = await _requestProvider.PostAsync<SavePhotoShelterHouse>(uri, item).ConfigureAwait(false);
            }
            return _savePhotoShelterHouse;
        }
    }
}
