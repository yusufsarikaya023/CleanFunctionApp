using CleanFunctionApp.Domain.Aggregation.Common;

namespace CleanFunctionApp.Domain.Aggregation.Users;

public class User : Entity
{
    private string name;
    public string Name { get => name;
        set =>
            name = value switch
            {
              var _ when string.IsNullOrEmpty(value) => throw new ArgumentNullException(nameof(Name)),
                _ => value.ToLower().Trim()
            };
    }

    private string email;
    public string Email
    {
        get => email;
        set =>
            email = value switch
            {
                var _ when string.IsNullOrEmpty(value) => throw new ArgumentNullException(nameof(Email)),
                var _ when !value.Contains('@') => throw new ArgumentException("Invalid_Email"),
                _ => value.ToLower().Trim()
            };
    }
}