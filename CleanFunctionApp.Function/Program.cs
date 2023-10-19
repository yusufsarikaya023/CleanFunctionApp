using CleanFunctionApp.Application;
using CleanFunctionApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
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