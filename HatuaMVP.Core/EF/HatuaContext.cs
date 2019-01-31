using HatuaMVP.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HatuaMVP.Core.EF
{
    public class HatuaContext : DbContext
    {
        public HatuaContext(DbContextOptions<HatuaContext> options) : base(options)
        {
        }

        public DbSet<Investor> Investors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investor>().ToTable("Investor");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<ServiceProvider>().ToTable("ServiceProvider");
            modelBuilder.Entity<Admin>().ToTable("Admin");
        }
    }
}