using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.PhotoComplaints
{
    public interface IPhotoComplaintsService
    {

        Task<List<Pasarela.Core.Models.PhotoComplaints.PhotoComplaints>> GetAllPhotosComplaintsAsync(int complaintId);

    }
}
