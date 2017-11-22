using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.Dog
{
    public interface IDogService
    {
        Task<List<Pasarela.Core.Models.Dog.Dog>> GetDogAsync();
    }
}
