using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace GRL.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger,
        IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogError(ex, "A concurrency error occurred.");

            await HandleExceptionAsync(context, ex, HttpStatusCode.Conflict,
                "A concurrency error occurred.");
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "A database update error occurred.");
            await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest, "A database error occurred.");
        }
        catch (KeyNotFoundException keyNotFoundEx)
        {
            _logger.LogWarning(keyNotFoundEx, "A KeyNotFoundException occurred.");
            await HandleExceptionAsync(context, keyNotFoundEx, HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode,
        string? customMessage = null)
    {
        var errorResponse = new ErrorResponse
        {
            Message = customMessage ?? exception.Message,
            Details = _env.IsDevelopment() ? exception.StackTrace : null
        };

        var payload = JsonSerializer.Serialize(errorResponse);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(payload);
    }

    private class ErrorResponse
    {
        public string? Message { get; set; }
        public string? Details { get; set; }
    }
}