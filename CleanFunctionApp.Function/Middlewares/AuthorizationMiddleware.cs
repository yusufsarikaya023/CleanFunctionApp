using System.Reflection;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace CleanFunctionApp.Function.Middlewares;

public class AuthorizationMiddleware : IFunctionsWorkerMiddleware
{
    private readonly IAuthorizationService service;
    public AuthorizationMiddleware(IAuthorizationService service)
    {
        this.service = service;
    }
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        // if that is swagger request, skip authorization
        if (context.FunctionDefinition.Name == "RenderSwaggerUI" || context.FunctionDefinition.Name == "RenderSwaggerDocument")
        {
            await next(context);
            return;
        }
        
        // Read request headers
        var headers = await context.GetHttpRequestDataAsync();
        var bearer = headers.Headers
            .FirstOrDefault(x => x.Key == "Authorization").Value;
        
        var targetMethod = GetTargetFunctionMethod(context);
        var attributes = targetMethod.GetCustomAttributes<AuthorizeAttribute>(true);

        if (attributes.Any() && bearer is null)
        {
            throw new UnauthorizedAccessException("Unauthorized");
        }

        if (bearer is not null && service.CheckAuthorization(bearer.FirstOrDefault()!, attributes.FirstOrDefault()?.Roles))
             await next(context);
        else
            throw new UnauthorizedAccessException("Unauthorized");
    }

    public static MethodInfo GetTargetFunctionMethod(FunctionContext context)
    {
        var entryPoint = context.FunctionDefinition.EntryPoint;
        var assemblyPath = context.FunctionDefinition.PathToAssembly;
        var assembly = Assembly.LoadFrom(assemblyPath);
        var typeName = entryPoint.Substring(0, entryPoint.LastIndexOf('.'));
        var type = assembly.GetType(typeName);
        var methodName = entryPoint.Substring(entryPoint.LastIndexOf('.') + 1);
        var method = type.GetMethod(methodName);
        return method;
    }
}