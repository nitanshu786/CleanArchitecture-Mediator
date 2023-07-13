using Application.Interface.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Command
{
    public class OneTimeLoginCommand : IRequest<bool>
    {
        public string Token { get; set; }
    }

    public class OneTimeLoginHandller : IRequestHandler<OneTimeLoginCommand, bool>
    {
        private readonly IStudentRepo _studentRepo;

        public OneTimeLoginHandller(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public async Task<bool> Handle(OneTimeLoginCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var find = _studentRepo.ExtractEmailFromToken(request.Token);
                if (!find)
                    return false;
                return true;
            }
            return false;
        }
    }
}
