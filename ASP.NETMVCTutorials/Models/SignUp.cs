using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NETMVCTutorials.Models
{
    public class SignUp
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserPassward { get; set; }

        public string UserGender { get; set; }

        public string UserEmail { get; set; }

        public string UserComment { get; set; }

    }
}