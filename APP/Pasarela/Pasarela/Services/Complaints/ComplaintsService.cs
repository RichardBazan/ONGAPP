using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Complaints;
using Pasarela.Core.Services.RequestProvider;
using Pasarela.Core.Models.Common;

namespace Pasarela.Core.Services.Complaints
{
    public class ComplaintsService : IComplaintsService
    {
        IRequestProvider _requestProvider;

        public ComplaintsService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<List<Models.Complaints.Complaints>> GetAllComplaintsAsync()
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.DenunciaEndpoint,
            string.Format(Constants.MethodsService.METHOD_COMPLAINTS));
            var listComplaints = await _requestProvider.GetAsync<List<Models.Complaints.Complaints>>(uri);
            return listComplaints;
        }

        public async Task<List<Models.Complaints.Complaints>> GetComplaintsResolveAsync()
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.DenunciaEndpoint,
            string.Format(Constants.MethodsService.METHOD_COMPLAINTS_RESOLVE));
            var listComplaintsResolve = await _requestProvider.GetAsync<List<Models.Complaints.Complaints>>(uri);
            return listComplaintsResolve;
        }

        public async Task<SaveComplaints> SaveComplaintsAsync(SaveComplaints _saveComplaints)
        {
            string uri = GlobalSetting.Instance.DenunciaEndpoint;
            var saveShelterHouse = await _requestProvider.PostAsync<SaveComplaints>(uri, _saveComplaints).ConfigureAwait(false);
            return saveShelterHouse;
        }
    }
}
