using Microsoft.AspNetCore.Server.IIS.Core;
using MiddlewareProject.DBContext;
using MiddlewareProject.Model;
using System.Net;
using System.Web.Http.Results;

namespace MiddlewareProject.Interface.IRepository.Repository
{
    public class UserPrinipal : IUserPrincipal
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpContext _httpContext;
        private CurrentUser _CurrentUser;


        public UserPrinipal(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context, CurrentUser currentUser)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
            _CurrentUser = currentUser;

        }

        public CurrentUser currentUser
        {
            get
            {
                var principal = _httpContext.User;
                if (principal.Identity.IsAuthenticated)
                {
                    var sessionId = principal.FindFirst("Session_id")?.Value;

                    if (sessionId != null)
                    {
                        Guid.TryParse(sessionId, out var newGuid);
                        if (newGuid != Guid.Empty)
                        {
                            var user = _context.Users.FirstOrDefault(x => x.SessionId == Convert.ToString(newGuid));
                            if (user != null)
                            {
                                var User_Id = principal.FindFirst("UserId")?.Value;
                                _CurrentUser.User_Id = User_Id;
                                return _CurrentUser;
                            }
                        }

                        throw new UnauthorizedAccessException("Unauthorized access");
                    }

                    throw new UnauthorizedAccessException("Unauthorized access");

                }
                return null;

            }

        }

        



    }
}
