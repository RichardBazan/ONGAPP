using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiONG.Models
{
    public class ComentarioModelDTO
    {

        public int Id;

        public string Description;

        public int ComplaintId;

        public int UserId;

        public string User;

        public int CountLikes;

    }
}