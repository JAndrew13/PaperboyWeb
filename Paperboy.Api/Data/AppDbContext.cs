using Microsoft.EntityFrameworkCore;
using Paperboy.Api.Data.Models;

namespace Paperboy.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<Alert> Alerts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Bot> Bots { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alert>()
            .HasOne(a => a.Bot)
            .WithMany(b => b.Alerts)
            .HasForeignKey(a => a.BotId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Bot)
            .WithMany(b => b.Orders)
            .HasForeignKey(o => o.BotId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Alert>()
            .HasOne(a => a.Order)
            .WithOne(o => o.Alert)
            .HasForeignKey<Order>(o => o.AlertId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
