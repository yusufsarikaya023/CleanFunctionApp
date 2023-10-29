
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CleanFunctionApp.Application.Abstract;
using FluentValidation;

namespace CleanFunctionApp.Application.UseCases.Users.DTO;

public class UserDto: IValidateable<UserDto>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    [JsonIgnore]
    public AbstractValidator<UserDto> Validator { get; } = new UserDtoValidation();
}