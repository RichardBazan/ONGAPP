using Pasarela.Core.Models.Dog;
using Pasarela.Core.Models.PhotoDog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.Dog
{
    public interface IDogService
    {
        Task<List<Pasarela.Core.Models.Dog.Dog>> GetDogOngAsync();

        Task<List<Pasarela.Core.Models.Dog.Dog>> GetDogUserAsync();

        Task<List<Pasarela.Core.Models.Dog.Dog>> GetDogAdoptAsync();

        Task<List<Pasarela.Core.Models.Dog.Dog>> GetDogAdoptionsAsync();

        Task<SaveDog> SaveDogAsync(SaveDog _saveDog);

        Task<bool> StateDogAsync(int id, Models.StateDog.StateDog _stateDog);

        Task<List<SavePhotoDog>> SavePhotoDogAsync(List<SavePhotoDog> _savePhotoDog);
    }
}
