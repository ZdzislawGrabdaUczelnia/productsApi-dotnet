using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseInMemoryDatabase("Products"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

// W metodzie Configure (dla Startup.cs)
// Zakomentuj lub usuñ liniê app.UseHttpsRedirection();

// LUB dla minimal API w Program.cs
// Zakomentuj lub usuñ liniê app.UseHttpsRedirection();

// Upewnij siê, ¿e Swagger jest skonfigurowany
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
