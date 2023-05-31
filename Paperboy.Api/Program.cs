using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Paperboy.Api.Data;
//using Paperboy.Api.Services;




var MyAllowAllOrigins = "_myAllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowAllOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
//builder.Services.AddScoped<WordService>();
//builder.Services.AddScoped<PlayerService>();

var app = builder.Build();

// Create and see the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    //Seeder.SeedWords(db);
    //Seeder.SeedPlayers(db);
}

var redirectRootUrl = app.Configuration.GetValue<string>("RedirectRootUrl", "");
if (string.IsNullOrEmpty(redirectRootUrl)) redirectRootUrl = "https://ambitious-island-0ab70521e.3.azurestaticapps.net/";
var options = new RewriteOptions()
        .AddRedirect("^$", redirectRootUrl, 302);
app.UseRewriter(options);

app.UseHttpsRedirection();

app.UseCors(MyAllowAllOrigins);

//// Add Google site verification.

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
