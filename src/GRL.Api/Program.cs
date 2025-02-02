using GRL.Api.Middlewares;
using Serilog;
using GRL.Infrastructure.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Production;

Log.Logger = GRL.Logging.LoggerConfigurationExtensions.ConfigureMinimalLogging(environmentName);

try
{
    Log.Information("Starting web host");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, _, loggerConfiguration) =>
    {
        GRL.Logging.LoggerConfigurationExtensions.SetupLogger(context.Configuration, loggerConfiguration);
    }, preserveStaticLogger: true);

    try
    {
        Log.Debug("Adding persistence services");
        builder.Services.AddPersistence(builder.Configuration);

        Log.Debug("Adding infrastructure services");
        builder.Services.AddInfrastructure();
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Failed to configure essential services or dependencies.");
        throw;
    }

    Log.Debug("Adding Controllers");
    builder.Services.AddControllers();

    Log.Debug("Adding Endpoints API Explorer");
    builder.Services.AddEndpointsApiExplorer();

    Log.Debug("Adding Swagger for API documentation");
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    Log.Debug("Setting API path base to /api");
    app.UsePathBase("/api");

    Log.Debug("Configuring forwarded headers for proxies");
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });

    Log.Debug("Configuring CORS policy to allow any origin, header, and method");
    app.UseCors(opt =>
    {
        opt.SetIsOriginAllowed(_ => true);
        opt.AllowAnyHeader();
        opt.AllowAnyMethod();
    });

    Log.Debug("Enabling Swagger and SwaggerUI for API documentation");
    app.UseSwagger();
    app.UseSwaggerUI();

    if (app.Environment.IsDevelopment())
    {
        Log.Debug("Development environment detected; enabling Developer Exception Page");
        app.UseDeveloperExceptionPage();
    }

    Log.Debug("Enabling HTTPS redirection");
    app.UseHttpsRedirection();

    Log.Debug("Configuring request logging with Serilog");
    app.UseSerilogRequestLogging();

    Log.Debug("Adding custom exception handling middleware");
    app.UseMiddleware<ExceptionHandlingMiddleware>();

    Log.Debug("Configuring Authorization");
    app.UseAuthorization();

    Log.Debug("Mapping controller routes");
    app.MapControllers();

    Log.Information("Running web application");
    await app.RunAsync();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Shutting down application");
    await Log.CloseAndFlushAsync();
}
