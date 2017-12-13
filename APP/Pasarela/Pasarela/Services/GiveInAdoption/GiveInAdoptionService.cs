using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.GiveInAdoption;
using Pasarela.Core.Services.RequestProvider;

namespace Pasarela.Core.Services.GiveInAdoption
{
    public class GiveInAdoptionService : IGiveInAdoptionService
    {

        IRequestProvider _requestProvider;

        public GiveInAdoptionService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<Models.GiveInAdoption.GiveInAdoption> SaveGiveInAdoptionAsync(Models.GiveInAdoption.GiveInAdoption _saveGiveInAdoption)
        {
            string uri = GlobalSetting.Instance.DarEnAdopcionEndPoint;
            var saveGiveInAdoption = await _requestProvider.PostAsync<Models.GiveInAdoption.GiveInAdoption > (uri, _saveGiveInAdoption).ConfigureAwait(false);
            return saveGiveInAdoption;
        }
    }
}
