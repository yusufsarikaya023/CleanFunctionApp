using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace CleanFunctionApp.Function;

public class AuthorizationService: IAuthorizationService
{
    private ClaimsPrincipal? Claims { get; set; }

    public void CheckAuthorization(string bearerToken)
    {
        // var handler = new JwtSecurityTokenHandler();
        // var token = handler.ReadJwtToken(bearerToken);
        // Claims = new ClaimsPrincipal(new ClaimsIdentity(token.Claims));
        var token = bearerToken.Replace("Bearer ", string.Empty);
        var scretKey =
            "PC4j0jQxlH73IiN6EBHd3KatApTp3uHylMo1dcCPulZJ8eMHOdzz5nAwr0eXptnMl9YUYc0FjP0v2PI8oQV4dq80OxyRO1KyE1ykymP2fpgitc395mnrTH1fBHlLs3R8xGGZ8FolBuHpzO8bn11HjPWeV6FsvZwGHIavWkhYv9WRhheb533zVVI6iGTIhNOO6oRrLvrBHx4drxqUBTMDzdOpsUrbgVz7QlmUicdgBv0bw89ZsW3uS2AMIq0m730Y";
        SymmetricSecurityKey key = new(Encoding.ASCII.GetBytes(scretKey));
        SigningCredentials credentals = new(key, SecurityAlgorithms.HmacSha256);
        var parameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(scretKey)),
            ValidateIssuer = true,
            ValidIssuer = "https://vpt-identityserver-dev-swe.azurewebsites.net",
            ValidateAudience = true,
            ValidAudience = "https://vpt-identityserver-dev-swe.azurewebsites.net/resources",
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            RequireExpirationTime = true,
        };
        
        Claims = new JwtSecurityTokenHandler().ValidateToken(token, parameters, out _);
    }
    
    public string GetSpecificClaim(string claimType)
    {
        return Claims?.FindFirst(claimType)?.Value!;
    }
    
}