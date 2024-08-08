using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NETMVCTutorials.Models
{
    public class ManagerContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
    }
}