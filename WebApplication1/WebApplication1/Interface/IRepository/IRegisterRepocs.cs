using MiddlewareProject.Model;

namespace MiddlewareProject.Interface.IRepository
{
    public interface IRegisterRepocs
    {
        bool IsUniqueUser(string email);
        ResponseVM? Login(string Email, string Passward);
        Register? Registers(Register register);
        ResponseVM GenerateToken(LoginVM loginVM, string session, int id);
       
    }
}
