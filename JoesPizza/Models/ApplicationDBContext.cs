using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JoesPizza.Models;

namespace JoesPizza.Models
{
    public class ApplicationDBContext : DbContext
    {
        internal object Session;

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=sqldbserver7001.database.windows.net;Database=EcommerceDB;User Id=apeksha;Password=sql.me7777");
        }

        
    }

}
