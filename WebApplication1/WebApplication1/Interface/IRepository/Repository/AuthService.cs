using MiddlewareProject.DBContext;
using MiddlewareProject.Model;
using System.IdentityModel.Tokens.Jwt;

namespace MiddlewareProject.Interface.IRepository.Repository
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public (string UserEmail, string userid) ExtractEmailFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var emailClaim = token.Claims.FirstOrDefault(c => c.Type == "Session_id");
            var userIdClaim = token.Claims.FirstOrDefault(c => c.Type == "UserId"); 

            var email = emailClaim?.Value;
            var userId = userIdClaim?.Value; 

            if (email != null && userId != null)
            {
                var finds = _context.Users.FirstOrDefault(x => x.SessionId == email); 
                if (finds != null)
                    return (finds.UserEmail, userId);
            }

            return (null,null);
        }

    }
}
