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
    public class GoogleCommand : IRequest<ExternalUser>
    {
        public GoogleCommand(ExternalUser externalUser)
        {
            UserId = externalUser.UserId;
            Email = externalUser.Email;
            Provider = externalUser.Provider;
            Name = externalUser.Name;

        }

        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
    }

    public class GoogleHandler : IRequestHandler<GoogleCommand, ExternalUser>
    {
        private readonly IRegisterRepo _registerRepo;

        public GoogleHandler(IRegisterRepo registerRepo)
        {
            _registerRepo = registerRepo;
        }

        public Task<ExternalUser> Handle(GoogleCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {

                ExternalUser externalUser = new ExternalUser()
                {
                    UserId = request.UserId,
                    Email = request.Email,
                    Provider = request.Provider,
                    Name = request.Name,
                };

                var finduser = _registerRepo.FindUser(externalUser);
                if (finduser != null)
                {
                    var login = _registerRepo.GoogleLogin(externalUser);
                    return login;
                }
                else
                {
                    _registerRepo.GoogleRegister(externalUser);
                    var logins = _registerRepo.GoogleLogin(externalUser);
                    return logins;
                }


            }

            return null;

        }
    }
}
