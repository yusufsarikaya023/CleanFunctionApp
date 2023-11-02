using CleanFunctionApp.Domain.Aggregation.Common;
using CleanFunctionApp.Domain.Aggregation.Users;

namespace CleanFunctionApp.Infrastructure.Repositories;
using Common;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context)
    {
    }

    public User[] Search()
    {
        return entity.ToArray();
    }

    public User[] Search(Specification<User>? specification, Pagination? pagination)
    {
        return entity.Filter(specification).Paginate(pagination).ToArray();
    }

    public void Insert(User user)
    {
        entity.Add(user);
    }

    public User Get(int id)
    {
        return entity.Find(id)!;
    }

    public User GetByEmail(string email)
    {
        return entity.FirstOrDefault(x => x.Email == email)!;
    }
}