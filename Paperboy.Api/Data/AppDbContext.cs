using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Metadata;

namespace Paperboy.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        // Tables go here
        public DbSet<User> Users => Set<User>();


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<DateWord>()
        //        .HasOne(e => e.Word)
        //        .WithMany(f => f.DateWords)
        //        .OnDelete(DeleteBehavior.ClientCascade);

        //}
    }
}
