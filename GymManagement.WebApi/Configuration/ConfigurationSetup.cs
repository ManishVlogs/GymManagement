using Microsoft.Extensions.Options;

namespace GymManagement.WebApi.Configuration
{
    public static class ConfigurationSetup
    {
        public static ConfigureHostBuilder AddConfigurations(this ConfigureHostBuilder host)
        {


            host.ConfigureAppConfiguration((context, config) =>
                {
                    var env = context.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
                });
            return host;
        }
    }
}
