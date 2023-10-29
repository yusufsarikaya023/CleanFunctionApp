using CleanFunctionApp.Application;
using CleanFunctionApp.Function.Middlewares;
using CleanFunctionApp.Infrastructure;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(x =>
    {
        x.UseMiddleware<ExceptionLoggingMiddleware>();
        x.UseNewtonsoftJson();
    })
    .ConfigureOpenApi()
    .ConfigureAppConfiguration(c =>
    {
        c.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
    })
    .ConfigureServices(s =>
        {
            var connectionString = Configuration
                .AppSettings
                .GetConnectionString("DefaultConnection")!;
            
            s.RegisterInfrastructure();
            s.RegisterApplication();
            s.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
        })
        .Build();
host.Run();