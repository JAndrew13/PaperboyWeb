namespace Paperboy.Api.Data
{
    public static class Seeder
    {
        public static void Seed(AppDbContext context) 
        {
            SeedUsers(context);
        }
        public static void SeedUsers(AppDbContext db)
        {
            if (db.Users.Any()) return;
            db.Users.Add(new User { Name = "John" });
            db.Users.Add(new User { Name = "Jane" });
            db.SaveChanges();
        }
    }
}
