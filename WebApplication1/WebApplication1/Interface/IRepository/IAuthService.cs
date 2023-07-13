using MiddlewareProject.Model;

namespace MiddlewareProject.Interface.IRepository
{
    public interface IAuthService
    {
        (string UserEmail, string userid) ExtractEmailFromToken(string jwtToken);
       
    }
}
