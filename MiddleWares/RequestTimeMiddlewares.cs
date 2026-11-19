
using System.Diagnostics;

namespace MVC01_BY_MennaTarek.Middleware
{
    // CLR
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stop = Stopwatch.StartNew();
            await _next.Invoke(context);

            stop.Stop();
            Console.WriteLine($"{context.Request.Path} --> {stop.ElapsedMilliseconds} ms");
        }
    }
}
