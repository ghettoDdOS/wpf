using course.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course
{
    public class ApplicationContext : DbContext
    {
        public DbSet<FinAsset> FinAssets { get; set; } = null!;
        public DbSet<Tiker> Tikers { get; set; } = null!;
        public DbSet<Security> Securities { get; set; } = null!;
        public DbSet<Bond> Bonds { get; set; } = null!;
        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=finance;Trusted_Connection=True;"); 
        }
    }
}
