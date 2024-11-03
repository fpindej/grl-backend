using Serilog;
using GRL.Infrastructure.Extensions;
using GRL.Persistence.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
GRL.Logging.LoggerConfigurationExtensions.SetupLogger(environmentName);

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ApplyMigrations();

app.UsePathBase("/api");
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseCors(opt =>
{
    opt.SetIsOriginAllowed(_ => true);
    opt.AllowAnyHeader();
    opt.AllowAnyMethod();
});

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    // Development only
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();