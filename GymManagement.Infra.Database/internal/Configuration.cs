using Microsoft.Extensions.Configuration;

namespace GymManagement.Infra.Database
{
    public static class Configuration
    {
        const string DEFAULT_CONNECTION_KEY = "DefaultConnection";
        private static readonly IConfiguration? _configuration;

        static Configuration()
        {
            _configuration = ConfigurationHelper._configuration;
        }

        public static string DefaultConnection
        {
            get
            {
                return DEFAULT_CONNECTION_KEY;
            }
        }

        public static string ProviderName
        {
            get
            {
                return _configuration.GetValue<string>($"DBConnection:{DefaultConnection}:ProviderName");
            }
        }

        public static string ConnectionString
        {
            get
            {
                return _configuration.GetValue<string>($"DBConnection:{DefaultConnection}:Name");
            }
        }

        public static string GetConnectionString(string connectionName)
        {
            return _configuration.GetValue<string>($"DBConnection:{connectionName}:Name");
        }

        public static string GetProviderName(string connectionName)
        {
            return _configuration.GetValue<string>($"DBConnection:{connectionName}:ProviderName");
        }

    }
}