using TaskManager.CLI.Data;
using TaskManager.CLI.Interfaces;
using TaskManager.CLI.Persistence;
using TaskManager.CLI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// 1. Register the Database Context
builder.Services.AddDbContext<AppDbContext>();

// 2. Register the Repository (Generic SQL version)
builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));

// 3. Register the Business Logic Service
builder.Services.AddTransient<TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
