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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinAsset>(builder =>
            {
                builder.Property(x => x.DataRegistration).HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });
            modelBuilder.Entity<Security>(builder =>
            {
                builder.Property(x => x.DataAccomodation).HasConversion<DateOnlyConverter, DateOnlyComparer>();
                builder.Property(x => x.DataReport).HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });
            modelBuilder.Entity<Bond>(builder =>
            {
                builder.Property(x => x.DataRepayment).HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=finance;Trusted_Connection=True;"); 
        }
    }
}
