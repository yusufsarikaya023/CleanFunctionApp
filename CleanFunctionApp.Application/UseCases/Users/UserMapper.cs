using AutoMapper;
using CleanFunctionApp.Domain.Aggregation.Users;
using CleanFunctionApp.Domain.Aggregation.Users.DTO;

namespace CleanFunctionApp.Application.UseCases.Users;

public class UserMapper: Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>();
    }
}