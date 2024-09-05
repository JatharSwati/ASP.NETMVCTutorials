using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETMVCTutorials.Models
{
    public class CookiesUser
    {
        [Key]
        public int CookiesUserId { get; set; }

        [Required(ErrorMessage = "Username is Required !")]
        public string Username { get; set; }
    }
}