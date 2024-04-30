using Application_MVCMediatRApp.UserProcessor.Queries;
using Data_MVCMediatRApp.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service_MVCMediatRApp.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager _configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();


// Connection String (replace with your actual connection string)
string connectionString = _configuration.GetConnectionString("MVCMediatRAppDefault");
// Add services to the container.
builder.Services.AddDbContext<MVCMediatRAppDbContext>(options =>
    options.UseSqlServer(connectionString));


// Register services
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUsersQuery).Assembly));




builder.Services.AddScoped(typeof(IUserService), typeof(UserService));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "MVCCallWebAPI", Version = "v2" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "MVCMediatRAppWebAPI");
});
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
