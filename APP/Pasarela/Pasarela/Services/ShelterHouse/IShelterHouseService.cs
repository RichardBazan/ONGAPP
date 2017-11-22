using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.ShelterHouse
{
    public interface IShelterHouseService
    {

        Task<List<Pasarela.Core.Models.ShelterHouse.ShelterHouse>> GetShelterHouseAsync();

    }
}
