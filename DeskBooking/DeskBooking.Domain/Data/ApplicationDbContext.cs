using DeskBooking.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooking.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {

        }

        public virtual DbSet<Desk> Desks { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }

            optionsBuilder.EnableSensitiveDataLogging().EnableDetailedErrors();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Desk)
                .WithMany(d => d.Reservations)
                .HasForeignKey(r => r.DeskId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.CancelReason).HasMaxLength(4000);

            modelBuilder.Entity<Desk>()
                .Property(e => e.RoomNumber).HasMaxLength(8);
        }
    }
}
