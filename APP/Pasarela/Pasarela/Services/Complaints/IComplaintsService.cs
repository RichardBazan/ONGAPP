using Pasarela.Core.Models.Complaints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.Complaints
{
    public interface IComplaintsService
    {

        Task<List<Pasarela.Core.Models.Complaints.Complaints>> GetAllComplaintsAsync();

        Task<List<Pasarela.Core.Models.Complaints.Complaints>> GetComplaintsByUserAsync(int userId);

        Task<SaveComplaints> SaveComplaintsAsync(SaveComplaints _saveComplaints);

    }
}
