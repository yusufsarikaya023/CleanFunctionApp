using CleanFunctionApp.Domain.Abstract;
using CleanFunctionApp.Domain.Aggregation.Users;
using CleanFunctionApp.Infrastructure.Repositories;

namespace CleanFunctionApp.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly Context context;
    public UnitOfWork(Context context)
    {
        this.context = context;
    }
    
    public ITransaction BeginTransaction() => new Transaction(context);
    
    private IUserRepository userRepository;
    public IUserRepository UserRepository() => userRepository = new UserRepository(context);
}