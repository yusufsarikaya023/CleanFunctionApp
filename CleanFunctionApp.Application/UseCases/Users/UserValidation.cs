using CleanFunctionApp.Domain.Aggregation.Users.DTO;
using FluentValidation;

namespace CleanFunctionApp.Application.UseCases.Users;

public class UserValidation : AbstractValidator<UserDto>
{
    public UserValidation()
    {
        RuleFor(x=>x.Email).NotEmpty().EmailAddress();
    }
}