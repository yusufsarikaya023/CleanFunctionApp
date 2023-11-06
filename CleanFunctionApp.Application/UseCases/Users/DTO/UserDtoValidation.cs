using FluentValidation;

namespace CleanFunctionApp.Application.UseCases.Users.DTO;

public class UserDtoValidation : AbstractValidator<UserDto>
{
    public UserDtoValidation()
    {
        RuleFor(x=>x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        RuleFor(x => x.Role).NotEmpty().MinimumLength(2);
    }
}