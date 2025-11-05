using ApartmentRental.DAL;
using ApartmentRental.DAL.Repository;
using ApartmentRental.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApartmentRental.BLL.Services.Interfaces;
using ApartmentRental.BLL.Services;
using ApartmentRentalAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IApartmentService, ApartmentService>();

var app = builder.Build();

app.MigrateDatabase();

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
