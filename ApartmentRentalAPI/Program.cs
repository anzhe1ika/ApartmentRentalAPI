using ApartmentRental.DAL;
using ApartmentRental.DAL.Repository;
using ApartmentRental.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApartmentRental.BLL.Services.Interfaces;
using ApartmentRental.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer("Server=localhost;Database=ApartmentRental;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IApartmentService, ApartmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
