namespace CleanFunctionApp.Function;

public interface IAuthorizationService
{
    
    void CheckAuthorization(string bearerToken);
    string GetSpecificClaim(string claimType);
}