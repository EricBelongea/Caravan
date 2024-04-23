﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan
{
    public class CaravanContext : DbContext
    {
        public DbSet<Passanger> Passangers;
        public DbSet<Wagon> Wagons;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=LaunchCaravan;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passanger>(entity =>
            {
                entity.HasKey(p => p.PassangerId);
                entity.Property(p => p.Name);
                entity.Property(p => p.Age);
                entity.Property(p => p.Destination);
                entity.HasOne(p => p.Wagon).WithMany(); // WithMany has an implicit reference back to Passanger. 
            });

            modelBuilder.Entity<Wagon>(entity =>
            {
                entity.HasKey(w => w.WagonId);
                entity.Property(w => w.Name);
                entity.Property(w => w.Covered);
                entity.Property(w => w.NumWheels);
                entity.HasMany(w => w.Passangers).WithOne(); // WithOne has an implicit reference back to Wagon. 
            });

            modelBuilder.Entity<Caravan>(entity =>
            {
                entity.HasKey(c => c.CaravanId);
                entity.HasMany(c => c.WagonList).WithOne();
            });
        }
    }
}
