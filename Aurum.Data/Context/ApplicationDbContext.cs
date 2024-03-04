using Aurum.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aurum.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Pondan> Pondans { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Pondan>().HasKey(p => p.Id);
        modelBuilder.Entity<Pondan>(e =>
            e.Property(e => e.Id).ValueGeneratedOnAdd()

        );
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Database=EFCoreTest;User Id=sa;Password=Password123;");
    }
}