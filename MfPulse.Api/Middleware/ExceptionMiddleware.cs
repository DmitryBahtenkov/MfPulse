using System;
using System.Threading.Tasks;
using MfPulse.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MfPulse.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (BusinessException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new {Message = ex.Message});
            }
            catch (NotFoundException)
            {
                context.Response.StatusCode = 404;
            }
            catch (ForbiddenException)
            {
                context.Response.StatusCode = 403;
            }
            catch(Exception exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new {Message = $"{exception.Message} {exception.StackTrace}"});
            }
        }
    }
}