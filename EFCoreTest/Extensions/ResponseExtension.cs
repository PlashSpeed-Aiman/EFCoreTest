using System.Net;
using EFCoreTest.ResponseObject;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTest.Extensions;

public static class OkExtension
{
    public static IActionResult OkWithDetails<T>(this Controller controller,string message ,T? data)
    {
        return new OkObjectResult(
            new ResponseStruct
            {
                Data = data,
                IsSuccess = true,
                Message = message,
                StatusCode = HttpStatusCode.OK.ToString(),
            }
        );
    }
}

public static class NotFoundExtension
{
    public static IActionResult NotFoundWithDetails<T>(this Controller controller, string message, T? data)
    {
        return new NotFoundObjectResult(
            new ResponseStruct
            {
                Data = data,
                IsSuccess = false,
                Message = message,
                StatusCode = HttpStatusCode.NotFound.ToString(),
            }
        );
    }
}

public static class BadRequestExtension
{
    public static IActionResult BadRequestWithDetails<T>(this Controller controller, string message, T? data)
    {
        return new BadRequestObjectResult(
            new ResponseStruct
            {
                Data = data,
                IsSuccess = false,
                Message = message,
                StatusCode = HttpStatusCode.BadRequest.ToString(),
            }
        );
    }
}

public static class UnauthorizedExtension
{
    public static IActionResult UnauthorizedWithDetails<T>(this Controller controller, string message, T? data)
    {
        return new UnauthorizedObjectResult(
            new ResponseStruct
            {
                Data = data,
                IsSuccess = false,
                Message = message,
                StatusCode = HttpStatusCode.Unauthorized.ToString(),
            }
        );
    }
}