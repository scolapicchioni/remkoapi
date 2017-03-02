using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace RemkoApi
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RemkoMiddleware
    {
        private readonly RequestDelegate _next;

        public RemkoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var bodyStream = context.Request.Body;

            var requestBody = new StreamReader(bodyStream).ReadToEnd();
            Console.WriteLine(requestBody);

            await _next(context);

            await context.Response.WriteAsync("OH HI!");
            
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RemkoMiddlewareExtensions
    {
        public static IApplicationBuilder UseRemkoMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RemkoMiddleware>();
        }
    }
}
