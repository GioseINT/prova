using Microsoft.EntityFrameworkCore;
using Prova.DAL.Entities;
using System;

namespace Prova.DAL
{
    public class AppDbConext : DbContext
    {
        public AppDbConext(DbContextOptions<AppDbConext> options ) : base(options)
        {
            
        } 

        public DbSet<Pet> Pets { get; set; } = default!;
        public DbSet<Veterinary> Veterinaries { get; set; } = default!;
        public DbSet<Appointment> Appointment { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Pet)
                .WithMany(p => p.Appointment)
                .HasForeignKey(a => a.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            // Explicit because FK property is named 'VeterinayId'
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Veterinary)
                .WithMany(v => v.Appointment)
                .HasForeignKey(a => a.VeterinayId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.Fee);

        }
    }
}
