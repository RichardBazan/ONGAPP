using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Complaints;

namespace Pasarela.Core.Services.Complaints
{
    public class ComplaintsMockService : IComplaintsService
    {
        private List<Pasarela.Core.Models.Complaints.Complaints> MockListComplaints = new List<Pasarela.Core.Models.Complaints.Complaints>
        {
            //new Pasarela.Core.Models.Complaints.Complaints{ Id = 1, Title = "Denuncia 1",Image="http://img.emol.com/2012/11/24/lobo1_1549.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Breed="Golden Retriever"},
            //new Pasarela.Core.Models.Complaints.Complaints{ Id = 2, Title = "Denuncia 2",Image="https://ep00.epimg.net/ccaa/imagenes/2014/08/26/madrid/1409075766_446915_1409076752_noticia_normal.jpg",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.", Breed="Rottweiler"},
            //new Pasarela.Core.Models.Complaints.Complaints{ Id = 3, Title="Denuncia 3",Image="https://i1.wp.com/www.mipuntodevista.com.mx/wp-content/uploads/2017/05/maltrato-animal.jpg?fit=700%2C325", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Breed="Bulldog"},
            //new Pasarela.Core.Models.Complaints.Complaints{ Id = 4, Title="Denuncia 4",Image="https://www.petalatino.com/wp-content/uploads/COSMO.jpg", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris a ipsum leo. Duis a vulputate ex. Morbi id metus non neque ullamcorper faucibus.",Breed="Pug"},
        };

        public async Task<List<Models.Complaints.Complaints>> GetAllComplaintsAsync()
        {
            return MockListComplaints;
        }

        public Task<List<Models.Complaints.Complaints>> GetComplaintsResolveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SaveComplaints> SaveComplaintsAsync(SaveComplaints _saveComplaints)
        {
            throw new NotImplementedException();
        }
    }
}
