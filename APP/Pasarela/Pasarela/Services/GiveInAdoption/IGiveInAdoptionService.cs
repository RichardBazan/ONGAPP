using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.GiveInAdoption
{
    public interface IGiveInAdoptionService
    {

        Task<Models.GiveInAdoption.GiveInAdoption> SaveGiveInAdoptionAsync(Models.GiveInAdoption.GiveInAdoption _saveGiveInAdoption);

    }
}
