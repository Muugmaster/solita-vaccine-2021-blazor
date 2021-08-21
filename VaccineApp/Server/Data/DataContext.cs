using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineApp.Shared.Models;
using VaccineApp.Shared.SeedDatabase;

namespace VaccineApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed data = new Seed();

            modelBuilder.Entity<Order>().HasData(data.SeedOrderData());
            modelBuilder.Entity<Vaccination>().HasData(data.SeedVaccinationData());

        }
    }
}
