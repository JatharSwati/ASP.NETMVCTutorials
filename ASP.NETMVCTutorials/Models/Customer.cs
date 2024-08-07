using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETMVCTutorials.Models
{
    public class Customer
    {
        [DisplayName("Id")]
        [Required(ErrorMessage = "Id is Mandatory")]
        public int CustomerId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is Mandatory")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name should be in between 5 to 20 ")]
        public string CustomerName { get; set; }

        [DisplayName("Age")]
        [Required(ErrorMessage = "Age is Mandatory")]
        [Range(20, 60, ErrorMessage = "Age should be in between 20 to 60")]
        public int? CustomerAge { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is Mandatory")]
        public string CustomerGender { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is Mandatory")]
        [RegularExpression("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage ="Invalid Email")]
        public string CustomerEmail { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is Mandatory")]
        [RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "UpperCase, LowerCase, Numbers, Symbols, 8 Characters")]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is Mandatory")]
        [Compare("CustomerPassword", ErrorMessage = "Password is not Same !")]
        [DataType(DataType.Password)]
        public string CustomerConfirmPassword { get; set; }

        [DisplayName("Organization Name")]
        [ReadOnly(true)]
        public string CustomerOrganizationName { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is Mandatory")]
        [DataType(DataType.MultilineText)]
        public string CustomerAddress { get; set; }

        [DisplayName("Joining Date")]
        [Required(ErrorMessage = "Joining Date is Mandatory")]
        [DataType(DataType.Date)]
        public string CustomerJoiningDate { get; set; }

        [DisplayName("Joining Time")]
        [Required(ErrorMessage = "Joining Time is Mandatory")]
        [DataType(DataType.Time)]
        public string CustomerJoiningTime { get; set; }
    }
}