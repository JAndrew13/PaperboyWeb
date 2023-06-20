namespace Paperboy.Api.Data.Models;

public static class Seeder
{
    public static void Seed(AppDbContext context)
    {
        SeedBots(context);
    }
    public static void SeedBots(AppDbContext db)
    {
        if (db.Bots.Any()) return;
        db.Bots.Add(new Bot 
        {
            Id = Guid.NewGuid(),
        });
        db.SaveChanges();
    }
}
