using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Complaints;
using Pasarela.Core.Services.RequestProvider;

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
            string uri = GlobalSetting.Instance.MaltratoEndpoint;
            var listComplaint = await _requestProvider.GetAsync<List<Models.Complaints.Complaints>>(uri);
            return listComplaint;
        }
    }
}
