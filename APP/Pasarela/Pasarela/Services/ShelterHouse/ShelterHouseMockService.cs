using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.PhotoShelterHouse;
using Pasarela.Core.Models.ShelterHouse;

namespace Pasarela.Core.Services.ShelterHouse
{
    public class ShelterHouseMockService : IShelterHouseService
    {

        private List<Pasarela.Core.Models.ShelterHouse.ShelterHouse> MockListShelterHouse = new List<Pasarela.Core.Models.ShelterHouse.ShelterHouse>
        {
            new Pasarela.Core.Models.ShelterHouse.ShelterHouse{ Id = 1, Name = "Casa Refugio 1", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Address="Av. Sucre 525" , Phone="246-2578"},
            new Pasarela.Core.Models.ShelterHouse.ShelterHouse{ Id = 2, Name = "Casa Refugio 2",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Address="Av. Sucre 525" , Phone="246-2578"},
            new Pasarela.Core.Models.ShelterHouse.ShelterHouse{ Id = 3, Name="Casa Refugio 3", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Address="Av. Sucre 525" , Phone="246-2578"},
            new Pasarela.Core.Models.ShelterHouse.ShelterHouse{ Id = 4, Name="Casa Refugio 4", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Address="Av. Sucre 525" , Phone="246-2578"},
        };

        public Task<List<Models.ShelterHouse.ShelterHouse>> GetAllShelterHouseAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Models.ShelterHouse.ShelterHouse>> GetShelterHouseAsync()
        {
            return MockListShelterHouse;
        }

        public Task<List<Models.ShelterHouse.ShelterHouse>> GetShelterHouseByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<SavePhotoShelterHouse> SavePhotoShelterHouseAsync(SavePhotoShelterHouse _savePhotoShelterHouse)
        {
            throw new NotImplementedException();
        }

        public Task<List<SavePhotoShelterHouse>> SavePhotoShelterHouseAsync(List<SavePhotoShelterHouse> _savePhotoShelterHouse)
        {
            throw new NotImplementedException();
        }

        public Task<SaveShelterHouse> SaveShelterHouseAsync(SaveShelterHouse _saveShelterHouse)
        {
            throw new NotImplementedException();
        }
    }
}
