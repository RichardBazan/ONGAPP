using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Models.User
{
    public class ChangePassword
    {
        public string PasswordActual { get; set; }
        public string PasswordNew { get; set; }
    }
}
