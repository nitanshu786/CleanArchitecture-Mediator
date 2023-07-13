using MediatR;
using MiddlewareProject.Interface.IRepository;
using MiddlewareProject.Model;

namespace MiddlewareProject.Command
{
    public class LoginCommand:IRequest<ResponseVM>
    {
        public LoginCommand(LoginVM login)
        {
            Email = login.Email;
            Password = login.Password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginHandller : IRequestHandler<LoginCommand, ResponseVM>
    {
        private readonly IRegisterRepocs _context;

        public LoginHandller(IRegisterRepocs context)
        {
            _context = context;
        }

        public async Task<ResponseVM> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request!= null)
            {
                var login = new LoginVM
                {
                    Email = request.Email,
                    Password = request.Password
                };
                ResponseVM? logins =  _context.Login(login.Email, login.Password);
                if (logins  != null)
                    return logins;
            }
            return null;
        }
    }
}
