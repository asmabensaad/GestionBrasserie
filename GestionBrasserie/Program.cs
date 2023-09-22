using GestionBrasserie.Models;
using GestionBrasserie.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("GestionBrasserie");
builder.Services.AddDbContext<GestionBrasserieDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:GestionBrasserie"]));

builder.Services.AddScoped<IBrasserieService, BrasserieService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();