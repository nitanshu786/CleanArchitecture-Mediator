using Domain.Entity;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Repository
{
    public class UserActivityFilter : IActionFilter
    {
        private readonly IApplicatinDbContext _context;

        public UserActivityFilter(IApplicatinDbContext context)
        {
            _context = context;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var data = "";
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];
            var url = $"{controller}/{action}";
            if(!string.IsNullOrEmpty(context.HttpContext.Request.QueryString.Value))
            {
                data = context.HttpContext.Request.QueryString.Value;
            }
            else
            {
                var userData = context.ActionArguments.FirstOrDefault();
                var stringUserData = JsonConvert.SerializeObject(userData);
                data = stringUserData;
            }
            var userName = context.HttpContext.User.Identity.Name;
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            if (ipAddress.Contains(":") && ipAddress.StartsWith("::ffff:"))
            {
                ipAddress = ipAddress.Substring(7);
            }

                StoreUserActivity(data, url, userName, ipAddress);
        }

        public void StoreUserActivity(string data, string url, string userName, string ipAddress)
        {
            var Activity = new UserActivity
            {
                Data= data,
                Url= url,
                UserName = userName,
                IpAddress=ipAddress
            };
            _context.UserActivities.Add(Activity);
            _context.SaveChanges();
        }
    }
}
