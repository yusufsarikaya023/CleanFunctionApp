using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanFunctionApp.Domain.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace CleanFunctionApp.Function;

public class AuthorizationService: IAuthorizationService
{
    private readonly IJwtOption JwtOption;

    public AuthorizationService(IJwtOption JwtOption)
    {
        this.JwtOption = JwtOption;
    }

    private ClaimsPrincipal? Claims { get; set; }

    public bool CheckAuthorization(string bearerToken , string[]? roles = null)
    {
        var token = bearerToken.Replace("Bearer ", string.Empty);
        SymmetricSecurityKey key = new(Encoding.ASCII.GetBytes(JwtOption.Secret));
        SigningCredentials credentals = new(key, SecurityAlgorithms.HmacSha256);
        var parameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = true,
            ValidIssuer = JwtOption.Issuer,
            ValidateAudience = true,
            ValidAudience = JwtOption.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            RequireExpirationTime = true,
        };
        
        Claims = new JwtSecurityTokenHandler().ValidateToken(token, parameters, out _);
        if (roles != null)
        {
            var role = Claims?.FindFirst(ClaimTypes.Role)?.Value;
            if (role == null) return false;
            return roles.Contains(role, StringComparer.InvariantCultureIgnoreCase);
        }
        return false;
    }
    
    public string GetSpecificClaim(string claimType)
    {
        return Claims?.FindFirst(claimType)?.Value!;
    }
    
}