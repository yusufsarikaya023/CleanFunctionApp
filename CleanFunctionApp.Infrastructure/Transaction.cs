using CleanFunctionApp.Domain.Abstract;
using Microsoft.EntityFrameworkCore.Storage;

namespace CleanFunctionApp.Infrastructure;

public class Transaction : ITransaction
{
    private readonly IDbContextTransaction scope;

    public Transaction(Context context)
    {
           scope = context.Database.BeginTransaction();
    }
    
    public Task CommitAsync() => scope.CommitAsync();
    public Task RollbackAsync() => scope.RollbackAsync();
    public void Dispose() => scope.Dispose();
}