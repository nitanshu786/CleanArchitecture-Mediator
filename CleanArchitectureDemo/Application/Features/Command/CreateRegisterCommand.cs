using Application.Interface.IRepository;
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
    public class CreateRegisterCommand : IRequest<Register>
    {
        public CreateRegisterCommand(Register register)
        {
            Email = register.Email;
            UserName = register.UserName;
            Password = register.Password;
        }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class CreateRegisterHandler : IRequestHandler<CreateRegisterCommand, Register>
    {
        private readonly IRegisterRepo _register;

        public CreateRegisterHandler(IRegisterRepo register)
        {
            _register = register;
        }

        public Task<Register> Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                try
                {
                    Register register = new Register()
                    {
                        Email = request.Email,
                        UserName = request.UserName,
                        Password = request.Password
                    };
                    var uniq = _register.IsUniqueUser(register.Email, register.Password);
                    if (!uniq)
                    {
                        var reg = _register.Registers(register);
                        return reg;
                    }
                    else
                        return null;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return null;
        }


    }
}
