using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;

namespace CleanFunctionApp.Function;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
public class AuthorizeAttribute : Attribute
{
    public string[] Roles { get; set; }

    public AuthorizeAttribute(params string[] roles)
    {
        Roles = roles;
    }
}