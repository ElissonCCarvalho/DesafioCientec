using Microsoft.EntityFrameworkCore;

using foundation.Models;

namespace foundation.Data
{
    public class FoundationDbContext : DbContext
    {
        public FoundationDbContext(DbContextOptions<FoundationDbContext> options) : base(options)
        {

        }

        public DbSet<Foundation> Foundations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var foundation = modelBuilder.Entity<Foundation>();

            foundation.ToTable("foundations");
            foundation.HasKey(x => x.Id);

            foundation.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            foundation.Property(x => x.Name).HasColumnName("name").IsRequired();
            foundation.Property(x => x.Cnpj).HasColumnName("cnpj").IsRequired();
            foundation.Property(x => x.Email).HasColumnName("email").IsRequired();
            foundation.Property(x => x.PhoneNumber).HasColumnName("phone_number").IsRequired();
            foundation.Property(x => x.SupportedInstitution).HasColumnName("supported_institution").IsRequired();
        }
    }
}