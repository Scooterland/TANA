using TANA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TANA.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Kunde> Kunder { get; set; }
		public DbSet<Rejse> Rejser {  get; set; }
		public DbSet<Tur> Turer { get; set; }
		public DbSet<RejseTur> RejseTurer { get; set; }
		public DbSet<Faktura> Fakturarer {  get; set; }
		public DbSet<Admin> Adminer { get; set; }
        public DbSet<Bruger> Brugere { get; set; }
        public DbSet<EmailSettings> EmailSettings { get; set; }
        public DbSet<TemplateEntity> Templates { get; set; }
        public DbSet<TemplateItemEntity> TemplateItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TemplateEntity>()
                        .HasMany(t => t.Items)
                        .WithOne(i => i.Template)
                        .HasForeignKey(i => i.TemplateEntityId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
