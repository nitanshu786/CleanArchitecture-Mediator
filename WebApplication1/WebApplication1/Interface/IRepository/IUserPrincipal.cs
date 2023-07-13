using MiddlewareProject.Model;

namespace MiddlewareProject.Interface.IRepository
{
    public interface IUserPrincipal
    {
        CurrentUser currentUser { get;}
    }
}
