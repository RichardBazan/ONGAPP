using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.Breed
{
    public interface IBreedService
    {

        Task<List<Models.Breed.Breed>> GetAllBreedAsync();

    }
}
