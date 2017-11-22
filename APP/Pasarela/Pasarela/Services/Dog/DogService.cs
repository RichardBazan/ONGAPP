using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Dog;

namespace Pasarela.Core.Services.Dog
{
    public class DogService : IDogService
    {
        public Task<List<Models.Dog.Dog>> GetDogAsync()
        {
            throw new NotImplementedException();
        }
    }
}
