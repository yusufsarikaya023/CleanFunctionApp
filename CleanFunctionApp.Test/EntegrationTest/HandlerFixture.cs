using AutoMapper;
using CleanFunctionApp.Application.UseCases.Users.DTO;

namespace CleanFunctionApp.Test.EntegrationTest;

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