using CleanFunctionApp.Domain.Aggregation.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CleanFunctionApp.Infrastructure;

public class Context : DbContext
{
    public Context(){}
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }
    public DbSet<User>? Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string conn = Configuration.AppSettings.GetConnectionString("DefaultConnection")!;
            optionsBuilder.UseSqlServer(conn);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}