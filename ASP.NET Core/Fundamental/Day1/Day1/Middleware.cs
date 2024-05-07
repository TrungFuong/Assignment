using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await WriteLogToFile(httpContext.Request);
            await _next(httpContext);
        }


        private async Task WriteLogToFile(HttpRequest Request)
        {
            string logFilePath = "log.txt";

            string log = $"Schema: {Request.Scheme}, Host: {Request.Host}, Path: {Request.Path}. Q.String: {Request.QueryString}";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                string requestBody = await reader.ReadToEndAsync();
                log += $", RequestBody: {requestBody}";
            }

            await File.AppendAllTextAsync(logFilePath, log);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
