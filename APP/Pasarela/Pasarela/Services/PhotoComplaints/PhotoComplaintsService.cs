using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.PhotoComplaints;
using Pasarela.Core.Services.RequestProvider;
using Pasarela.Core.Models.Common;

namespace Pasarela.Core.Services.PhotoComplaints
{
    public class PhotoComplaintsService : IPhotoComplaintsService
    {

        IRequestProvider _requestProvider;

        public PhotoComplaintsService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<List<Models.PhotoComplaints.PhotoComplaints>> GetAllPhotosComplaintsAsync(int complaintId)
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.FotoMaltratoEndPoint,
            string.Format("{0}" + Constants.MethodsService.METHOD_PHOTO_COMPLAINTS, complaintId));
            var photosByComplaints = await _requestProvider.GetAsync<List<Models.PhotoComplaints.PhotoComplaints>>(uri);
            return photosByComplaints;
        }
    }
}
