using CleanFunctionApp.Application.UseCases.Users.DTO;
using FluentValidation;

namespace CleanFunctionApp.Application.UseCases.Users;

public class UserDtoValidation : AbstractValidator<UserDto>
{
    public UserDtoValidation()
    {
        RuleFor(x=>x.Email).NotEmpty().EmailAddress();
    }
}