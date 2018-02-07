using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Dog;
using Pasarela.Core.Models.Common;
using Pasarela.Core.Services.RequestProvider;
using Pasarela.Core.Models.StateDog;
using Pasarela.Core.Models.PhotoDog;

namespace Pasarela.Core.Services.Dog
{
    public class DogService : IDogService
    {

        IRequestProvider _requestProvider;

        public DogService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }
        public Task<List<Models.Dog.Dog>> GetDogAdoptAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Models.Dog.Dog>> GetDogOngAsync()
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.MascotaEndPoint,
            string.Format(Constants.MethodsService.METHOD_DOGS_ADOPT_ONG));
            var listDogs = await _requestProvider.GetAsync<List<Models.Dog.Dog>>(uri);
            return listDogs;
        }

        public async Task<List<Models.Dog.Dog>> GetDogUserAsync()
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.MascotaEndPoint,
            string.Format(Constants.MethodsService.METHOD_DOGS_ADOPT_USER));
            var listDogs = await _requestProvider.GetAsync<List<Models.Dog.Dog>>(uri);
            return listDogs;
        }

        public async Task<List<Models.Dog.Dog>> GetDogAdoptionsAsync()
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.MascotaEndPoint,
            string.Format(Constants.MethodsService.METHOD_DOGS_ADOPTIONS));
            var listDogs = await _requestProvider.GetAsync<List<Models.Dog.Dog>>(uri);
            return listDogs;
        }

        public async Task<SaveDog> SaveDogAsync(SaveDog _saveDog)
        {
            string uri = GlobalSetting.Instance.MascotaEndPoint;
            var saveDog = await _requestProvider.PostAsync<SaveDog>(uri, _saveDog).ConfigureAwait(false);
            return saveDog;
        }

        public async Task<bool> StateDogAsync(int id, StateDog _stateDog)
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.MascotaEndPoint,
            string.Format("/{0}", id.ToString()));
            var stateDog = await _requestProvider.PutAsync<StateDog>(uri, _stateDog).ConfigureAwait(false);
            return stateDog;
        }

        public async Task<List<SavePhotoDog>> SavePhotoDogAsync(List<SavePhotoDog> _savePhotoDog)
        {
            string uri = GlobalSetting.Instance.FotoMascotaEndPoint;
            var savePhotoShelterHouse = await _requestProvider.PostAsync<List<SavePhotoDog>>(uri, _savePhotoDog).ConfigureAwait(false);
            return savePhotoShelterHouse;
        }
    }
}
