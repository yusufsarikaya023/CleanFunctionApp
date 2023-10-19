using Microsoft.Extensions.Configuration;

namespace CleanFunctionApp.Infrastructure;

public class Configuration
{
    /// <summary>
    /// Get App settings
    /// </summary>
    public static IConfigurationRoot AppSettings { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile($"local.settings.json", optional: true, reloadOnChange: true)
        .Build();
}