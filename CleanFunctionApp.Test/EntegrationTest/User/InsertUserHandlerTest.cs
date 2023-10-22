using AutoMapper;
using CleanFunctionApp.Application.UseCases.Users;
using CleanFunctionApp.Domain.Abstract;
using CleanFunctionApp.Domain.Aggregation.Users.DTO;
using Moq;

namespace CleanFunctionApp.Test.EntegrationTest.User;
using CleanFunctionApp.Domain.Aggregation.Users;



public class InsertUserHandlerTest: Repository, IClassFixture<HandlerFixture>
{
    public readonly HandlerFixture fixture;

    public InsertUserHandlerTest(HandlerFixture fixture)
    {
        this.fixture = fixture;
    }
    
    [Theory,MemberData(nameof(GetNegativeUsers), MemberType = typeof(InsertUserHandlerTest))]
    public async Task InsertUserHandler_Should_Throw_Error(UserDto userDto)
    {
        // Arrange
        var command = new InsertUserCommand(userDto);
        var unitOfWork = new Mock<IUnitOfWork>();
        var userRepository = new Mock<IUserRepository>();
        
        // Act & Assert
        userRepository.Setup(x => x.Insert(It.IsAny<User>()));
        unitOfWork.Setup(x => x.UserRepository())
            .Returns(userRepository.Object);
        
        var handler = new InsertUserHandler(unitOfWork.Object,fixture.mapper); 
        await Assert.ThrowsAsync<AutoMapperMappingException>( async() =>
        {
         await  handler.Handle(command, CancellationToken.None);
        });
    }
    
    [Theory,MemberData(nameof(GetPositiveUsers), MemberType = typeof(InsertUserHandlerTest))]
    public async Task InsertUserHandler_Should_Return_Success(UserDto userDto)
    {
        // Arrange
        var command = new InsertUserCommand(userDto);
  
        // Act
        var handler = new InsertUserHandler(unitOfWork, fixture.mapper); 
        await handler.Handle(command, CancellationToken.None);
        var user = unitOfWork.UserRepository().Get(userDto.Id);
        
        // Assert
        Assert.Equal(userDto.Email.ToLower().Trim(), user.Email);
        Assert.Equal(userDto.Name.ToLower().Trim(), user.Name);
    }
    
    
    public static IEnumerable<object[]> GetNegativeUsers()
    {
        yield return new object[]
        { 
            new UserDto(){ Email = "hatice", Name = "Yusuf", Id = 0 }
        };
        yield return new object[]
        {
            new UserDto() { Email = "yusuf", Name = "Yusuf", Id = 0 }
        };
    }

    public static IEnumerable<object[]> GetPositiveUsers()
    {
        yield return new object[]
        {
            new UserDto() { Email = "yusufsarikaya@gmail.com", Name = "Yusuf", Id = 1 }
        };
        yield return new object[]
        {
            new UserDto() { Email = "haticesarikaya@gmail.com", Name = "Yusuf", Id = 2 }
        };
    }
}