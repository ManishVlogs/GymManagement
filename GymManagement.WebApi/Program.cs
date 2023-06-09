using System.Data.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using GymManagement.WebApi.Configuration;
using GymManagement.Domain.Core.Models.Common;
using GymManagement.Infra.CrossCutting.IoC;
using GymManagement.Infra.Database;

var builder = WebApplication.CreateBuilder(args);
var appBuilder = builder.Host.AddConfigurations();
//ConfigurationManager _configuration = builder.Configuration;
//var identitySettingsSection = _configuration.GetSection("AppIdentitySettings");


// JWT Authentication Settings

// Add services to the container.


builder.Services.Configure<AppIdentitySettings>(builder.Configuration.GetSection("AppIdentitySettings"));


#region File logging
//builder.Services.AddTransient<Log>();

#endregion

builder.Services.AddCorsPolicy(builder.Configuration);
builder.Services.AddJWTTokenServices(builder.Configuration);
builder.Services.AddApiVersioningSetup();
builder.Services.AddControllers();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSwaggerSetup();
builder.Services.AddCompressionSetup();

builder.Services.AddRazorPages();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

//builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
//{
//    var libraryPath = Path.GetFullPath(
//        Path.Combine(builder.Environment.ContentRootPath, "App_Data\\EmailTemplates"));
//    options.FileProviders.Add(new PhysicalFileProvider(libraryPath));
//});

#region Adding dependencies
NativeInjectorBootStrapper.RegisterServices(builder.Services);
#endregion


#region Database
DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
ConfigurationHelper.Initialize(builder.Configuration);
//builder.Services.AddApplicationInsightsTelemetry();
#endregion

var app = builder.Build();
//ok
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerSetup();
}
else
{
    app.UseSwaggerSetup();
    app.UseHsts();
}

//app.UseAuthentication();
app.UseAuthorization();

//configure exception middleware
//app.UseMiddleware(typeof(GlobalExceptionHandler));

app.UseCorsPolicy();
app.UseResponseCompression();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();