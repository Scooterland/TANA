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
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(local);DataBase=RejseplanDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Kunde> Kunder { get; set; }
		public DbSet<Rejse> Rejser {  get; set; }
		public DbSet<Tur> Turer { get; set; }
		public DbSet<RejseTur> RejseTurer { get; set; }
		public DbSet<Faktura> Fakturarer {  get; set; }
		public DbSet<Admin> Adminer { get; set; }
        public DbSet<Bruger> Brugere { get; set; }
    }
}
