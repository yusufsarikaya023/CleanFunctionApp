using System.Security.Claims;

namespace CleanFunctionApp.Domain.Abstract;

public interface IJwtService
{
    string BuildToken(IEnumerable<Claim> claims);
}