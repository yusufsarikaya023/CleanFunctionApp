using CleanFunctionApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CleanFunctionApp.Test.EntegrationTest;

public abstract class Repository
{
    protected DbContextOptionsBuilder<Context>? optionsBuilder;
    protected Context? context;
    protected UnitOfWork unitOfWork;
    public Repository()
    {
        optionsBuilder = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(databaseName: "nunit");
        context = new Context(optionsBuilder);
        unitOfWork = new UnitOfWork(context);
    }

    public int SaveChanges() => context!.SaveChanges();
}