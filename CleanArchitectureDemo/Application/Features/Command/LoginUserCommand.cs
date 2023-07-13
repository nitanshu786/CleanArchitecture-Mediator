using Application.DTO;
using Application.Interface.IRepository;
using Application.VmModel;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Command
{
    public class LoginUserCommand : IRequest<LoginReturn>
    {
        public LoginUserCommand(LoginVM login)
        {
            Email = login.Email;
            Password = login.Password;
        }

        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginReturn>
    {
        private readonly IRegisterRepo _register;

        public LoginUserHandler(IRegisterRepo register)
        {
            _register = register;
        }

        public async Task<LoginReturn> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var logs = _register.Login(request.Email, request.Password);
                if (logs != null)
                    return await logs;
            }

            return null;
        }
    }
}
