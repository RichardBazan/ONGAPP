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
            new Banner{ Id = 1, PictureUrl = "http://photos1.blogger.com/x/blogger2/7767/1068332094510395/740/z/199678/gse_multipart4759.jpg"},
            new Banner{ Id = 2, PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4d/Logo_de_Plaza_Vea.jpg"},
            new Banner{ Id = 3, PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d4/Logo_Tottus.png"},
            new Banner{ Id = 4, PictureUrl = "http://marketing-peru.beglobal.biz/wp-content/uploads/2013/03/logo-wong.jpg"},
        };

        public async Task<List<Banner>> GetBannerAsync()
        {
            return MockBanner;
        }
    }
}
