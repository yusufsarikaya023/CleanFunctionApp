namespace CleanFunctionApp.Domain.Abstract;

public interface ITransaction: IDisposable
{
    Task CommitAsync();
    Task RollbackAsync();
}