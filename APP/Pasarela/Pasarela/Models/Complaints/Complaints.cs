using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.PhotoComplaints;

namespace Pasarela.Core.Models.Complaints
{
    public class Complaints
    {


        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Breed { get; set; }
        public string Description { get; set; }
        public List<PhotoComplaints.PhotoComplaints> Photos { get; set; }

    }
}
