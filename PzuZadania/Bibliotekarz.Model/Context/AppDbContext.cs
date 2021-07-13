using Bibliotekarz.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Model.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Customer> Borrowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().Property(e => e.Author).HasMaxLength(200);
            modelBuilder.Entity<Book>().Property(e => e.Title).HasMaxLength(150);

            modelBuilder.Entity<Book>().HasOne(e => e.Borrower).WithMany(b => b.Books)
                .HasForeignKey(e => e.BorrowerId).IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
