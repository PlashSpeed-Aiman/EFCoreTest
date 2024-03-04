using System.Net;
using System.Text.Json;
using Aurum.Domain.DomainExceptions;
using EFCoreTest.ResponseObject;

namespace EFCoreTest.Middlewares;

/// <summary>
/// The ExceptionMiddleware class is a middleware class that handles exceptions thrown by the application.
/// Each exception is caught and the response is written to the client.
/// </summary>
public class ExceptionMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
            _logger.LogError(ex.Message);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError; // 500 if unexpected
        
        if (exception is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
        
        code = exception switch
        {   
            NotFoundException => HttpStatusCode.NotFound,
            UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            ArgumentNullException or InvalidOperationException => HttpStatusCode.BadRequest,
            _ => code
        };

        var result = JsonSerializer.Serialize(new ResponseStruct
        {
            IsSuccess = false,
            Message = exception.Message,
            StatusCode = code.ToString(),
        });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}