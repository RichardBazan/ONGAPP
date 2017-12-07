using Pasarela.Core.Models.ShelterHouse;
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

        Task<List<Models.ShelterHouse.ShelterHouse>> GetAllShelterHouseAsync();

        Task<List<Models.ShelterHouse.ShelterHouse>> GetShelterHouseByUserAsync(int userId);

        Task<SaveShelterHouse> SaveShelterHouseAsync(SaveShelterHouse _saveShelterHouse);

    }
}
