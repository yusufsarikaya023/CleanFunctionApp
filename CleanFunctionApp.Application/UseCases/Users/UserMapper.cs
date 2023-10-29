using AutoMapper;
using CleanFunctionApp.Application.UseCases.Users.DTO;
using CleanFunctionApp.Domain.Aggregation.Users;

namespace CleanFunctionApp.Application.UseCases.Users;

public class UserMapper: Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}