using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Breed;
using Pasarela.Core.Services.RequestProvider;
using Pasarela.Core.Models.Common;

namespace Pasarela.Core.Services.Breed
{
    public class BreedService : IBreedService
    {

        IRequestProvider _requestProvider;

        public BreedService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<List<Models.Breed.Breed>> GetAllBreedAsync()
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.RazaEndPoint,
            string.Format(Constants.MethodsService.METHOD_ALL_BREED));
            var listBreed = await _requestProvider.GetAsync<List<Models.Breed.Breed>>(uri);
            return listBreed;
        }
    }
}
