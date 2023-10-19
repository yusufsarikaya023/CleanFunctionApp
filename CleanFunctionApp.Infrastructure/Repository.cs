using Microsoft.EntityFrameworkCore;

namespace CleanFunctionApp.Infrastructure;

public class Repository<T> where T : class
{
    protected readonly Context context;
    protected readonly DbSet<T> entity;

    protected Repository(Context context)
    {
        this.context = context;
        entity = context.Set<T>();
    }
}