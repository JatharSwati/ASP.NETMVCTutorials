using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NETMVCTutorials.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Salary { get; set; }
    }
}