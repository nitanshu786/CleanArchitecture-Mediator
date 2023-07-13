//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using MiddlewareProject.ResponseTimeKey;
//using System.Diagnostics;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace MiddlewareProject.ConfigureJWT
//{
//    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
//    public class CustomResponseMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public CustomResponseMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public  Task Invoke(HttpContext httpContext)
//        {
//            httpContext.Response.OnStarting(() =>
//            {
//                var claimsPrincipal = httpContext.User as ClaimsPrincipal;
//                var customClaimValue = claimsPrincipal?.FindFirstValue(ResponseTime.JWTTOKENTIME);
//                httpContext.Response.Headers[ResponseTime.JWTTOKENTIME] = Convert.ToString( customClaimValue);
//                return Task.CompletedTask;
//            });           
//            return _next(httpContext);
//        }
//    }

//    // Extension method used to add the middleware to the HTTP request pipeline.
//    public static class CustomResponseMiddlewareExtensions
//    {
//        public static IApplicationBuilder UseCustomResponseMiddleware(this IApplicationBuilder builder)
//        {
//            return builder.UseMiddleware<CustomResponseMiddleware>();
//        }
//    }
//}
