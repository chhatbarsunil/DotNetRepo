
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi_MVCMediateRApp.Services;
using WebApi_MVCMediateRApp.Data.MediatRWebApiDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();


// Register services
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddScoped(typeof(IUserService), typeof(UserService));

// Regigst DbContext
builder.Services.AddDbContext<MediatRWebApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MediatRWebApi")));

// Way-2
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Register from multiple assembly.
//services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(ICustomerService).Assembly);
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());   
 

app.UseAuthorization();

app.MapControllers();

app.Run();
