using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TodoSample.Application.Exceptions;

namespace TodoSample.WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IDictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;

            _exceptionHandlers = new Dictionary<Type, Func<HttpContext, Exception, Task>>
            {
                { typeof(NotFoundException), HandleNotFoundException },
            };
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Type type = ex.GetType();
                if (_exceptionHandlers.ContainsKey(type))
                {
                    await _exceptionHandlers[type].Invoke(context, ex);
                }
                else
                {
                    await HandleUnhandledException(context, ex);
                }
            }
        }

        private async Task HandleNotFoundException(HttpContext context, Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.NotFound;

            var result = JsonSerializer.Serialize(new { title = ex?.Message, 
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                status = 404});
            await response.WriteAsync(result);
        }

        private async Task HandleUnhandledException(HttpContext context, Exception ex)
        {
            Log.Logger.Error($"An unhandled exception occurred:{ex.Message}", ex);

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            var result = JsonSerializer.Serialize(new { title = ex?.Message, 
                type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                status = 500});
            await response.WriteAsync(result);
        }
    }
}
