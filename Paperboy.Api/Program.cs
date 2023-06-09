using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Paperboy.Api.Data;
using Paperboy.Api.Data.Models;
using Paperboy.Api.Services;

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("secrets.json");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.Configure<Secrets>(options => builder.Configuration.GetSection("Secrets").Bind(options));

builder.Services.AddScoped<AlertService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ExchangeService>();
builder.Services.AddScoped<BotService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<ReportService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    Seeder.SeedBots(db);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("UseSwagger", false))
{
    app.UseSwagger();
    app.UseSwaggerUI();
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
