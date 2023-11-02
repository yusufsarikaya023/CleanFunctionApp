using CleanFunctionApp.Application.Services;

namespace CleanFunctionApp.Test.Application.UnitTest;

public class PasswordHashServiceTest
{
    [Fact]
    public void ComputeSha256Hash_ShouldReturnHashedString()
    {
        // Arrange
        var passwordHashService = new PasswordHashService();
        var password = "1986.Yusuf";
        var expected = "75add91a291846476b3763f25ac1f5fa82e0f6391ef5d77361a8970f12ed7e84";

        // Act
        var actual = passwordHashService.ComputeSha256Hash(password);

        // Assert
        Assert.Equal(expected, actual);
    }
}