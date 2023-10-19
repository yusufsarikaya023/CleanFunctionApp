namespace CleanFunctionApp.Domain.Aggregation.Users;

public interface IUserRepository
{
    User[] Search();
}