using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Banner;

namespace Pasarela.Core.Services.Home
{
    public class HomeMockService : IHomeService
    {
        private List<Banner> MockBanner = new List<Banner>
        {
            new Banner{ Id = 1, PictureUrl = "https://pbs.twimg.com/media/BmZTaECCIAEbQIe.jpg"},
            new Banner{ Id = 2, PictureUrl = "http://animaleshoy.net/wp-content/uploads/2014/10/170781__dogs-pinscher-pekiness-poodle-chihuahua-toy-terrier_p.jpg"},
            new Banner{ Id = 3, PictureUrl = "http://perrocontento.com/wp-content/uploads/2015/11/COMO-AYUDO.png"},
            new Banner{ Id = 4, PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d6/Alza-tu-mano.jpg"},
        };

        public async Task<List<Banner>> GetBannerAsync()
        {
            return MockBanner;
        }
    }
}
