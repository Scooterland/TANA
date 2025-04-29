using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TANA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TANA.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Bruger> Brugere { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bruger>(entity =>
            {
                entity.HasKey(e => e.BrugerId);
                entity.Property(e => e.Navn).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Rolle).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PasswordHash).IsRequired();
            });
        }
    }
}
