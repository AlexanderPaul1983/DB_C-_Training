using LabExercise.Web;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the EFCore Context to use an SQLite DB called Production
var connectionString = new SqliteConnectionStringBuilder { DataSource = "Production.db" }.ToString();
builder.Services.AddDbContext<ExerciseContext>(x => x.UseSqlite(connectionString));

// Register MediatR
builder.Services.AddMediatR(option => option.RegisterServicesFromAssemblyContaining<Program>());

// Create the WebApplication with the DI Container
var app = builder.Build();

// Make sure, that tre database is deleted and re-created on every start
using (var scope = app.Services.CreateScope())
{
    var database = scope.ServiceProvider.GetRequiredService<ExerciseContext>().Database; 
    database.EnsureDeleted();
    database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add the maps using the UseMaps extension method 
app.UseMaps();

app.Run();

