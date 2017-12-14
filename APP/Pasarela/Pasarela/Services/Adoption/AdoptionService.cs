using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Adoption;
using Pasarela.Core.Services.RequestProvider;

namespace Pasarela.Core.Services.Adoption
{
    public class AdoptionService : IAdoptionService
    {

        IRequestProvider _requestProvider;

        public AdoptionService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<Models.Adoption.Adoption> SaveAdoptionAsync(Models.Adoption.Adoption _saveAdoption)
        {
            string uri = GlobalSetting.Instance.AdopcionEndPoint;
            var saveAdoption = await _requestProvider.PostAsync <Models.Adoption.Adoption> (uri, _saveAdoption).ConfigureAwait(false);
            return saveAdoption;
        }
    }
}
