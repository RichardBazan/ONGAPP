using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.Donate
{
    public interface IDonateService
    {

        Task<List<Models.Donate.Donate>> GetDonateByShelterHouseAsync(int shelterHouseId);

    }
}
