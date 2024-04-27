using BaseMVCApp.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager _configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connection String (replace with your actual connection string)
string connectionString = _configuration.GetConnectionString("BaseMVCAppDefault");

builder.Services.AddDbContext<BaseDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
