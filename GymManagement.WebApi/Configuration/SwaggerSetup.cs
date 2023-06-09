using GymManagement.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace GymManagement.WebApi.Configuration
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "GymRegistration.WebApi",
                        Version = "v1",
                        Description = "API Gym Registration",
                    });

                c.DescribeAllParametersInCamelCase();
                c.OrderActionsBy(x => x.RelativePath);

                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }

                c.OperationFilter<RemoveVersionFromParameter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                //c.OperationFilter<AuthenticationRequirementsOperationFilter>();

                c.DocInclusionPredicate((version, desc) =>
                {
                    if (!desc.TryGetMethodInfo(out var methodInfo))
                        return false;

                    var versions = methodInfo
                       .DeclaringType?
                   .GetCustomAttributes(true)
                   .OfType<ApiVersionAttribute>()
                   .SelectMany(attr => attr.Versions);

                    var maps = methodInfo
                       .GetCustomAttributes(true)
                   .OfType<MapToApiVersionAttribute>()
                   .SelectMany(attr => attr.Versions)
                   .ToList();

                    return versions?.Any(v => $"v{v}" == version) == true
                             && (!maps.Any() || maps.Any(v => $"v{v}" == version));
                });

                // To Enable authorization using Swagger (JWT)    
                // oauth2
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                    Scheme = "Bearer"

                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                        },

                        new string[] {}

                    }
                });



                // Maps all structured ids to the guid type to show correctly on swagger 

                var allGuids = typeof(Guid).Assembly.GetTypes().Where(type => typeof(Guid).IsAssignableFrom(type) && !type.IsInterface)
                    .ToList();
                foreach (var guid in allGuids)
                {
                    c.MapType(guid, () => new OpenApiSchema { Type = "string", Format = "uuid" });
                }

            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerSetup(this IApplicationBuilder app)
        {
            app.UseSwagger(c => { c.RouteTemplate = "dev/swagger/{documentName}/swagger.json"; });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/dev/swagger/v1/swagger.json", "Gym Application API v1");
                options.SwaggerEndpoint("/dev/swagger/v2/swagger.json", "Gym Application API v2");
                options.RoutePrefix = "dev/swagger";

            });
            return app;
        }

        public class AuthenticationRequirementsOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                if (operation.Security == null)
                    operation.Security = new List<OpenApiSecurityRequirement>();


                var scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" } };
                operation.Security.Add(new OpenApiSecurityRequirement
                {
                    [scheme] = new List<string>()
                });
            }
        }
    }
}
