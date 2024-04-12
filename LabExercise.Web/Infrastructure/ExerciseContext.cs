using Microsoft.EntityFrameworkCore;

namespace LabExercise.Web.Infrastructure;

public class ExerciseContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options)
    {
    }
}
