using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanFunctionApp.Application;

public static class Injector
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(typeof(Assembly).Assembly);
        services.AddMediatR(cfg => cfg.
            RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
    }
}