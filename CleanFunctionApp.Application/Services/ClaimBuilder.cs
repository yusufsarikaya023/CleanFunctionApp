using System.Security.Claims;

namespace CleanFunctionApp.Application.Services;

public class ClaimBuilder
{
    private ICollection<Claim> claims = new HashSet<Claim>();
    
    public static ClaimBuilder Create() => new();
    
    public ClaimBuilder SetId(string id)
    {
        claims.Add(new Claim(ClaimTypes.NameIdentifier, id));
        return this;
    }
    
    public ClaimBuilder SetName(string name)
    {
        claims.Add(new Claim(ClaimTypes.Name, name));
        return this;
    }
    
    public ClaimBuilder SetRole(string role)
    {
        claims.Add(new Claim(ClaimTypes.Role, role));
        return this;
    }
    
    public ClaimBuilder SetEmail(string email)
    {
        claims.Add(new Claim(ClaimTypes.Email, email));
        return this;
    }
    
    public ICollection<Claim> Build() => claims;
}