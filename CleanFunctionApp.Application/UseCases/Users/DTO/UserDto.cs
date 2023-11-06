using CleanFunctionApp.Application.Abstract;
using CleanFunctionApp.Application.Common;
using FluentValidation;
using Newtonsoft.Json;

namespace CleanFunctionApp.Application.UseCases.Users.DTO;

public class UserDto: EntityDto, IValidateable<UserDto>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    [JsonIgnore]
    public AbstractValidator<UserDto> Validator { get; } = new UserDtoValidation();
}