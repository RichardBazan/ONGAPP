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
            new Pasarela.Core.Models.Dog.Dog{ Id = 1, Name = "Ruffo",Image="https://t1.ea.ltmcdn.com/es/razas/5/5/0/img_55_golden-retriever-o-cobrador-dorado_0_orig.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Breed="Golden Retriever"},
            new Pasarela.Core.Models.Dog.Dog{ Id = 2, Name = "Keka",Image="https://mascotafiel.com/wp-content/uploads/2015/12/perro-rottweiler_opt.jpg",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.", Breed="Rottweiler"},
            new Pasarela.Core.Models.Dog.Dog{ Id = 3, Name="Vodka",Image="http://cdn3-www.dogtime.com/assets/uploads/gallery/bulldog-dog-breed-pictures/1-threequartersitting.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Breed="Bulldog"},
            new Pasarela.Core.Models.Dog.Dog{ Id = 4, Name="Puchi",Image="http://cdn3-www.dogtime.com/assets/uploads/gallery/pug-dog-breed-pictures/3-sidesitting.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Breed="Pug"},
        };
        public async Task<List<Models.Dog.Dog>> GetDogAsync()
        {
            return MockListDog;
        }
    }
}
