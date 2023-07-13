using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiddlewareProject.Interface.IRepository;
using MiddlewareProject.Model;

namespace MiddlewareProject.Command
{
    public class RegisterCommand:IRequest<Register>
    {
        public RegisterCommand(Register register)
        {
            UserName = register.UserName;
            Email = register.Email;
            Pasword = register.Pasword;
        }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Pasword { get; set; }
    }

    public class RegisterCommandHanddler : IRequestHandler<RegisterCommand, Register>
    {
        private readonly IRegisterRepocs _context;

        public RegisterCommandHanddler(IRegisterRepocs context)
        {
            _context = context;
        }

        public async Task<Register?> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if(request!=null)
            {
                var register= new Register
                {
                  UserName = request.UserName,
                  Email = request.Email,
                  Pasword = request.Pasword,
                };
                var create = _context.Registers(register);
                return create;
            }
            return null;
        }
    }
}
