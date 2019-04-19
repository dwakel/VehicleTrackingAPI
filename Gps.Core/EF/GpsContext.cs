using Gps.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gps.Core.EF
{
    public class GpsContext : DbContext
    {
        public GpsContext(DbContextOptions<GpsContext> options) : base(options)
        {
        }

        public GpsContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<HomeLocation> HomeLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<HomeLocation>().ToTable("HomeLocation");
        }
    }
}