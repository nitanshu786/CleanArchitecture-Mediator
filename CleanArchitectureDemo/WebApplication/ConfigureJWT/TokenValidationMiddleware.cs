using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.ConfigureJWT
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //var token = GetTokenFromRequest(context); 

            //if (!string.IsNullOrEmpty(token))
            //{
                //if (IsTokenBlacklisted(token)) 
                //{
                //    context.Response.StatusCode = 401; 
                //    return;
                //}
            //}

            //await _next(context); 
        }

        //private string GetTokenFromRequest(HttpContext context)
        //{
            
        //}

        //private bool IsTokenBlacklisted(string token)
        //{
            
        //}
    }

}
