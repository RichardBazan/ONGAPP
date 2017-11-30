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
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.MaltratoEndpoint,
            string.Format(Constants.MethodsService.METHOD_ALL_COMPLAINTS));
            var listComplaints = await _requestProvider.GetAsync<List<Models.Complaints.Complaints>>(uri);
            return listComplaints;
        }

        public async Task<List<Models.Complaints.Complaints>> GetComplaintsByUserAsync(int userId)
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.MaltratoEndpoint,
            string.Format("/{0}" + Constants.MethodsService.METHOD_COMPLAINTS_USER, userId));
            var listComplaintsByUser = await _requestProvider.GetAsync<List<Models.Complaints.Complaints>>(uri);
            return listComplaintsByUser;
        }
    }
}
