using Microsoft.EntityFrameworkCore;
using Core.Store.Domain.Entities;

namespace Infrastructure.Store.Persistence.Persistence;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

    public DbSet<Person> People => Set<Person>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Person>(e =>
        {
            e.ToTable("TB_PEOPLE");
            e.HasKey(p => p.Id);
            e.Property(p => p.Name).IsRequired().HasMaxLength(150);
            e.Property(p => p.Email).IsRequired().HasMaxLength(200);
            e.HasIndex(p => p.Email).IsUnique();

            // Novo campo CEP: NVARCHAR2(8), opcional
            e.Property(p => p.Cep).HasMaxLength(8);
        });
    }
}
