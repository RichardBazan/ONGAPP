using Newtonsoft.Json;
using System;

namespace Pasarela.Core.Models.User
{
    public class UserInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstLastName { get; set; }

        public string SecondLastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
