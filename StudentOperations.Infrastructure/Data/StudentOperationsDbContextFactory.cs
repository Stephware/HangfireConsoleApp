using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudentOperations.Infrastructure.Data;

public class StudentOperationsDbContextFactory
    : IDesignTimeDbContextFactory<StudentOperationsDbContext>
{
    public StudentOperationsDbContext CreateDbContext(string[] args)
    {
        // Instructor's LocalDB default for Windows; override for macOS/Docker
        // by setting ConnectionStrings__StudentDatabase in the terminal.
        var connection = Environment.GetEnvironmentVariable(
            "ConnectionStrings__StudentDatabase");

        if (string.IsNullOrWhiteSpace(connection))
        {
            connection =
                "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=StudentOperationsDb;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;";
        }

        var optionsBuilder =
            new DbContextOptionsBuilder<StudentOperationsDbContext>();

        optionsBuilder.UseSqlServer(connection);

        return new StudentOperationsDbContext(optionsBuilder.Options);
    }
}
