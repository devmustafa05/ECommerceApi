using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace ECommerce.Application.Exceptions
{
    internal class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                // http context i gecirmeye calisiyoruz
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            if(exception.GetType() == typeof(ValidationException))
            {
                return httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Errors = ((ValidationException)exception).Errors.Select(s => s.ErrorMessage),
                    StatusCode = StatusCodes.Status400BadRequest
                }.ToString());
            }

            List<string> errors = new()
            {
                $"Error Message: {exception.Message}",
                $"Error Description: {exception.InnerException?.ToString()}"
            };

            return httpContext.Response.WriteAsync(new ExceptionModel()
            {
                Errors = errors,
                StatusCode = statusCode
            }.ToString());

        }

        private static int GetStatusCode(Exception exception) =>
            exception  switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
        }
    
}
