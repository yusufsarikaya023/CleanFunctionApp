namespace CleanFunctionApp.Domain.Aggregation.Users;

public interface IUserRepository
{
    User[] Search();
    void Insert(User user);
    User Get(int id);
}