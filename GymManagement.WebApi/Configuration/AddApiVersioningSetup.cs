using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.WebApi.Configuration
{
    public static class ApiVersioningSetup
    {
        public static IServiceCollection AddApiVersioningSetup(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                              new HeaderApiVersionReader("x-api-version"),
                                                              new MediaTypeApiVersionReader("x-api-version"));
            });
            return services;
        }
    }
}
