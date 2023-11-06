
namespace CleanFunctionApp.Function;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
public class AuthorizeAttribute : Attribute
{
    public string[] Roles { get; }

    public AuthorizeAttribute(params string[] roles)
    {
        Roles = roles;
    }
}