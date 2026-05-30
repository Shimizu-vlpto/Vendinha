using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using VendinhaBackend.Models;

namespace VendinhaBackend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Divida> Dividas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().HasIndex(c => c.Cpf).IsUnique();

        modelBuilder.Entity<Divida>()
            .HasOne(d => d.Cliente)
            .WithMany(c => c.Dividas)
            .HasForeignKey(d => d.ClienteId);
    }
}