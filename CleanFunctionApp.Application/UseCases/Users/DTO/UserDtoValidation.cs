using FluentValidation;

namespace CleanFunctionApp.Application.UseCases.Users.DTO;

public class UserDtoValidation : AbstractValidator<UserDto>
{
    public UserDtoValidation()
    {
        RuleFor(x=>x.Email).NotEmpty().EmailAddress();
    }
}