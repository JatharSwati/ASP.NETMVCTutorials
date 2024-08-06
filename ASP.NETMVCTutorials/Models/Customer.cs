using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETMVCTutorials.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Id is Mandatory")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Name is Mandatory")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Age is Mandatory")]
        public int? CustomerAge { get; set; }

        [Required(ErrorMessage = "Gender is Mandatory")]
        public string CustomerGender { get; set; }

        [Required(ErrorMessage = "Email is Mandatory")]
        public string CustomerEmail { get; set; }
    }
}