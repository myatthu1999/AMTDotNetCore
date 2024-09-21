using AMTDotNetCore.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMTDotNetCore.ConsoleApp
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 string connectionString = "Data Source=.;Initial Catalog=AMTDotNetCore;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connectionString);
    }

}

        public DbSet<BlogDataModel> Blogs { get; set; }
    }
}
