namespace GymManagement.WebApi.Configuration
{
    public static class CorsPolicySetup
    {
        private static string CorsPolicy = nameof(CorsPolicy);

        internal static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            var corsSettings = configuration.GetValue<string>("AllowedHosts");

            return services.AddCors(opt =>
            opt.AddPolicy(CorsPolicy, policy =>
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    //.AllowCredentials()
                    .WithOrigins(corsSettings.Split(";", StringSplitOptions.RemoveEmptyEntries))));
        }

        internal static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app) =>
            app.UseCors(CorsPolicy);
    }
}
