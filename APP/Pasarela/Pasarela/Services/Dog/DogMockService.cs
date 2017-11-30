using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Dog;

namespace Pasarela.Core.Services.Dog
{
    public class DogMockService : IDogService
    {
        private List<Pasarela.Core.Models.Dog.Dog> MockListDog = new List<Pasarela.Core.Models.Dog.Dog>
        {
            new Pasarela.Core.Models.Dog.Dog{ Id = 1, Name = "Ruffo", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Breed="Golden Retriever"},
            new Pasarela.Core.Models.Dog.Dog{ Id = 2, Name = "Keka",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.", Breed="Rottweiler"},
            new Pasarela.Core.Models.Dog.Dog{ Id = 3, Name="Vodka", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Breed="Bulldog"},
            new Pasarela.Core.Models.Dog.Dog{ Id = 4, Name="Puchi", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Breed="Pug"},
        };

        public Task<List<Models.Dog.Dog>> GetDogAdoptAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Dog.Dog>> GetDogAdoptionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Dog.Dog>> GetDogOngAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.Dog.Dog>> GetDogUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}
