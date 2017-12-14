using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.Adoption
{
    public interface IAdoptionService
    {
        Task<Models.Adoption.Adoption> SaveAdoptionAsync(Models.Adoption.Adoption _saveAdoption);

    }
}
