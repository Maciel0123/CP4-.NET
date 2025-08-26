using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
// Alias evita colisão com o namespace Core.Person
using PersonEntity = Core.Person.Domain.Entities.Person;

namespace Infrastructure.Person.Persistence.Persistence
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }

        public DbSet<PersonEntity> People => Set<PersonEntity>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            // ✅ Tipagem explícita resolve o CS1503
            b.Entity<PersonEntity>(PersonMap);
        }

        private static void PersonMap(EntityTypeBuilder<PersonEntity> e)
        {
            e.ToTable("TB_PEOPLE");
            e.HasKey(p => p.Id);
            e.Property(p => p.Name).IsRequired().HasMaxLength(150);
            e.Property(p => p.Email).IsRequired().HasMaxLength(200);
            e.HasIndex(p => p.Email).IsUnique();
            e.Property(p => p.Cep).HasMaxLength(8);
        }
    }
}
