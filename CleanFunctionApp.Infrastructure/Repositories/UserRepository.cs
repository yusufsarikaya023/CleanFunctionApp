using CleanFunctionApp.Domain.Aggregation.Users;

namespace CleanFunctionApp.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context)
    {
    }

    public User[] Search()
    {
        return entity.ToArray();
    }
    
    public void Insert(User user)
    {
        entity.Add(user);
    }
}