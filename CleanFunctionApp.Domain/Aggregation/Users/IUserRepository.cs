using CleanFunctionApp.Domain.Aggregation.Common;

namespace CleanFunctionApp.Domain.Aggregation.Users;

public interface IUserRepository
{
    User[] Search(Specification<User> specification,Pagination? pagination);
    void Insert(User user);
    User Get(int id);
    User GetByEmail(string email);
}