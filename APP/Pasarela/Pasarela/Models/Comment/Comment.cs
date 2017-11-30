using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Models.Comment
{
    public class Comment
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public int ComplaintId { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public int CountLikes { get; set; }

    }
}
