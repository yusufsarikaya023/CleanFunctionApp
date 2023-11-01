using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CleanFunctionApp.Domain.Abstract;
using Microsoft.IdentityModel.Tokens;

namespace CleanFunctionApp.Function.Services;

public class JwtService: IJwtService
{
   private readonly IJwtOption option;
   public JwtService(IJwtOption option)
   {
      this.option = option;
   }
   public string BuildToken(IEnumerable<Claim> claims)
   {
      SymmetricSecurityKey key = new(Encoding.ASCII.GetBytes(option.Secret));
      SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
      
      JwtSecurityToken jwt = new(
         claims: claims,
         issuer: option.Issuer,
         expires:DateTime.Now.AddMinutes(option.Expires),
         audience: option.Audience,
         notBefore: DateTime.Now,
         signingCredentials: credentials
      );
      
      var token = new JwtSecurityTokenHandler().WriteToken(jwt);

      return token;
   }
}