using LabExercise.Web.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace LabExercise.Tests.Helpers;

public class BaseTestWithExerciseContext : IDisposable, IAsyncDisposable
{
    protected readonly ExerciseContext DbContext;
    
    protected BaseTestWithExerciseContext()
    {
        // Create connection string for an in memory SQLite DB
        var connectionString = new SqliteConnectionStringBuilder {DataSource  = "file::memory:" }.ToString();
        // Create the Options for the Context
        var options = new DbContextOptionsBuilder<ExerciseContext>().UseSqlite(connectionString).Options;
        // Create the Context using the Options
        DbContext = new ExerciseContext(options);

        // Make sure, that the Database is created
        DbContext.Database.EnsureCreated();
    }

    public void Dispose() => DbContext.Dispose();

    public async ValueTask DisposeAsync() => await DbContext.DisposeAsync();
}