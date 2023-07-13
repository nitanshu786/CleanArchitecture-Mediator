using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using MiddlewareProject.DBContext;
using MiddlewareProject.Interface.IRepository;
using MiddlewareProject.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MiddlewareProject.ConfigureJWT
{
    public class UserActivitys : IActionFilter
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserPrincipal _userPrincipal;
      //private const string ResponseTimeKey = "ResponseTimeKey";

        public UserActivitys(ApplicationDbContext context, IUserPrincipal userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;



        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Start the Timer
            //context.HttpContext.Items[ResponseTimeKey] = Stopwatch.StartNew();

            var userName = _userPrincipal.currentUser;
            if (userName != null)
            {
                ActionExecute(context, userName.User_Id);
            }
            else
            {
                var Controller = context.HttpContext.Request.Path.Value;
                string Method = context.HttpContext.Request.Method;
                string URL = $"{Controller}/{Method}";
                if (URL == "/api/RegisterApi/Login/POST" || URL== "/api/RegisterApi/POST")
                {
                    ActionExecute(context,null); 
                }
                else 
                {
                    throw new UnauthorizedAccessException();
                }
            }

        }

        private void ActionExecute(ActionExecutingContext context, string? Userid)
        {
            string data = "";
            string? Controller = context.HttpContext.Request.Path.Value;
            string Method = context.HttpContext.Request.Method;
            string URL = $"{Controller}/{Method}";

            if (!string.IsNullOrEmpty(context.HttpContext.Request.QueryString.Value))
            {

                data = context.HttpContext.Request.QueryString.Value;
            }
            else
            {
                KeyValuePair<string, object?> userData = context.ActionArguments.FirstOrDefault();
                string stringUserData = JsonConvert.SerializeObject(userData);
                data = stringUserData;
            }
            string traceid = context.HttpContext.TraceIdentifier.ToString();
            //var userName = context.HttpContext.User.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");

            string ipAddress = GetIpAddress(context.HttpContext);

            StoreUserActivity(data, URL, traceid, ipAddress, Userid);
        }
        public void StoreUserActivity(string data, string url, string traceid, string ipAddress, string? user_id)
        {
            UserActivity Activity = new UserActivity
            {
                Data = data,
                Url = url,
                User_Id = user_id,
                TraceId = traceid,
                IpAddress = ipAddress
            };
            _context.Activitys.Add(Activity);
            _context.SaveChanges();
        }


        private string GetIpAddress(HttpContext httpContext)
        {
            System.Net.IPAddress? remoteIpAddress = httpContext.Connection.RemoteIpAddress;

            if (remoteIpAddress != null)
            {
                if (remoteIpAddress.IsIPv4MappedToIPv6)
                    remoteIpAddress = remoteIpAddress.MapToIPv4();

                return remoteIpAddress.ToString();
            }


            return "Unknown";
        }


    }
}
