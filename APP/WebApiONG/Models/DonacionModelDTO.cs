using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiONG.Models
{
    public class DonacionModelDTO
    {

        public int Id;

        public int IdUser;

        public string User;

        public int IdShelterHouse;

        public string ShelterHouse;

        public List<DonacionProductoModelDTO> Products;

    }
}