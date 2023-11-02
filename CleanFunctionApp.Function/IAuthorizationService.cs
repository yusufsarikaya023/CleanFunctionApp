namespace CleanFunctionApp.Function;

public interface IAuthorizationService
{
    
    bool CheckAuthorization(string bearerToken, string[]? roles = null);
    string GetSpecificClaim(string claimType);
}