using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DigitalRetailers.Models;

namespace DigitalRetailers.Models
{
    public class ApplicationDBContext : DbContext
    {
        internal object Session;

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=H5CG1220SMZ;Database=EcommerceDB;Integrated security=true");
        }

        
    }

}
