namespace CleanFunctionApp.Test.Domain.UnitTest.User;
using CleanFunctionApp.Domain.Aggregation.Users;
public class UserTest
{
    [Fact]
    public void User_Should_Return_Correct_Value()
    {
        // Arrange
        var email = " yusufsarikaya023@gmail.com ";
        var name = " Yusuf ";

        // Act
        var user = new User()
        {
            Email = email,
            Name = name,
        };

        // Assert
        Assert.Equal(email.ToLower().Trim(), user.Email);
        Assert.Equal(name.ToLower().Trim(), user.Name);
    }

    [Fact]
    public void User_Email_Should_Throw_Error()
    {
        // Arrange
        var email = "yusuf";
        var name = "yusuf";


        // Act & Assert
    var ex =    Assert.Throws<ArgumentException>(() =>
        {
            var user = new User()
            {
                Email = email,
                Name = name
            };
        });
    Assert.Equal("Invalid_Email",ex.Message);
    }

    [Fact]
    public void User_Should_Throw_Name_Error()
    {
        // Arrange
        var email = "yusufsarikaya023@gmail.com";
        var name = "";

        // Act & Assert
      var ex =  Assert.Throws<ArgumentNullException>(() =>
        {
            var user = new User()
            {
                Email = email,
                Name = name
            };
        });
      Assert.Equal("Name",ex.ParamName);
    }

    [Fact]
    public void User_Should_Throw_Email_Error()
    {
        // Arrange
        var email = "";
        var name = "yusuf";

        // Act & Assert
      var ex=  Assert.Throws<ArgumentNullException>(() =>
        {
            var user = new User()
            {
                Email = email,
                Name = name
            };
        });
      Assert.Equal("Email",ex.ParamName);
    }
}