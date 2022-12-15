using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class SqlContext:DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapDB;Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public  DbSet<Brand> Brands { get; set; }
    }
}
