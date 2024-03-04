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
        //convert database type to string from guid
        modelBuilder.Entity<Pondan>().Property(rp => rp.Id).HasConversion(
            v => v.ToString(),
            value => new Guid(value));
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Database=EFCoreTest;User Id=sa;Password=Password123;");
    }
}