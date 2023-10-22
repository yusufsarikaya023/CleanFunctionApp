using AutoMapper;

namespace CleanFunctionApp.Test.EntegrationTest;
using CleanFunctionApp.Domain.Aggregation.Users;
using CleanFunctionApp.Domain.Aggregation.Users.DTO;

public class HandlerFixture
{
    public readonly IMapper mapper;

    public HandlerFixture()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserDto, CleanFunctionApp.Domain.Aggregation.Users.User>().ReverseMap();
        });
        mapper = config.CreateMapper();
    }
}