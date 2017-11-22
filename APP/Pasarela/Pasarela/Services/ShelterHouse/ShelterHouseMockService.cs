using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.ShelterHouse;

namespace Pasarela.Core.Services.ShelterHouse
{
    public class ShelterHouseMockService : IShelterHouseService
    {

        private List<Pasarela.Core.Models.ShelterHouse.ShelterHouse> MockListShelterHouse = new List<Pasarela.Core.Models.ShelterHouse.ShelterHouse>
        {
            new Pasarela.Core.Models.ShelterHouse.ShelterHouse{ Id = 1, Name = "Casa Refugio 1",Image="https://i.ytimg.com/vi/Jo0Lk_9iCYY/hqdefault.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Address="Av. Sucre 525" , Phone="246-2578"},
            new Pasarela.Core.Models.ShelterHouse.ShelterHouse{ Id = 2, Name = "Casa Refugio 2",Image="https://k45.kn3.net/B866B7AFA.jpg",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Address="Av. Sucre 525" , Phone="246-2578"},
            new Pasarela.Core.Models.ShelterHouse.ShelterHouse{ Id = 3, Name="Casa Refugio 3",Image="http://perrofeliz.org/wp-content/images/elcampito-refugio-arg-4.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Address="Av. Sucre 525" , Phone="246-2578"},
            new Pasarela.Core.Models.ShelterHouse.ShelterHouse{ Id = 4, Name="Casa Refugio 4",Image="http://www.sbs.com.au/topics/sites/sbs.com.au.topics/files/dog_7.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Address="Av. Sucre 525" , Phone="246-2578"},
        };
        public async Task<List<Models.ShelterHouse.ShelterHouse>> GetShelterHouseAsync()
        {
            return MockListShelterHouse;
        }
    }
}
