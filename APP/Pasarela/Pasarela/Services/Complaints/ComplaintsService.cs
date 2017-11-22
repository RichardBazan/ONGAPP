using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Complaints;

namespace Pasarela.Core.Services.Complaints
{
    public class ComplaintsService : IComplaintsService
    {
        public Task<List<Models.Complaints.Complaints>> GetAllComplaintsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
