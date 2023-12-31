using CleanFunctionApp.Application;
using CleanFunctionApp.Application.Common;
using CleanFunctionApp.Domain.Abstract;
using CleanFunctionApp.Function;
using CleanFunctionApp.Function.Middlewares;
using CleanFunctionApp.Function.Services;
using CleanFunctionApp.Infrastructure;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(x =>
    {
        x.UseMiddleware<ExceptionLoggingMiddleware>();
        x.UseMiddleware<AuthorizationMiddleware>();
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
            s.AddScoped<IAuthorizationService, AuthorizationService>();
            s.AddDbContext<Context>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            s.AddSingleton<IOpenApiConfigurationOptions>(_ =>
            {
                OpenApiConfigurationOptions options = new OpenApiConfigurationOptions
                {
                    Info = new OpenApiInfo
                    {
                        Version = "2.0",
                        Title = "Serverless Job Portal API",
                        Description = "This is the API on which the serverless job portal engine is running.",
                        TermsOfService = new Uri("https://www.jobportal.se"),
                        Contact = new OpenApiContact
                        {
                            Name = "Jobportal",
                            Email = "info@jobportal.se",
                            Url = new Uri("https://www.jobportal.se")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "License",
                            Url = new Uri("https://www.jobportal.se")
                        }
                    },
                    OpenApiVersion = OpenApiVersionType.V3,
                    IncludeRequestingHostName = true,
                    ForceHttps = false,
                    ForceHttp = false,
                };
                return options;
            });
            
            s.AddOptions<JwtOption>().Configure<IConfiguration>((s, c) => 
                c.GetSection(nameof(JwtOption)).Bind(s));
            s.AddSingleton<IJwtOption>(x => x.GetRequiredService<IOptions<JwtOption>>().Value);
            s.AddSingleton<IJwtService, JwtService>();

        })
        .Build();

host.Run();