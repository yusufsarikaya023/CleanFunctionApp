using CleanFunctionApp.Domain.Abstract;

namespace CleanFunctionApp.Application.Common;

public class JwtOption: IJwtOption
{
    public string Secret { get; set; } = String.Empty;
    public string Issuer { get; set; } = String.Empty;
    public string Audience { get; set; } = String.Empty;
    public int Expires { get; set; } 
}