<<<<<<< HEAD
=======
using Microsoft.EntityFrameworkCore;
using OrderKaBA.DatabaseConnection;

>>>>>>> 2200c58488b3f1d8e1b0d916555c9009ba877a81
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
=======
// Configure PostgreSQL connection
builder.Services.AddDbContext<OrderKaBaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

>>>>>>> 2200c58488b3f1d8e1b0d916555c9009ba877a81
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
