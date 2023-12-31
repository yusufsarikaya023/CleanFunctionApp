using CleanFunctionApp.Domain.Aggregation.Users;

namespace CleanFunctionApp.Domain.Abstract;

public interface IUnitOfWork
{
    ITransaction BeginTransaction();
    Task CommitAsync(CancellationToken cancellationToken);
    IUserRepository UserRepository();
}