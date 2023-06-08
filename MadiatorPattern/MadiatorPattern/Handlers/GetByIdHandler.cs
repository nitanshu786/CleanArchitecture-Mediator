using MadiatorPattern.CommandQuery;
using MadiatorPattern.Model;
using MadiatorPattern.RepoServices.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MadiatorPattern.Handlers
{
    public class GetByIdHandler : IRequestHandler<GetStudentQueryId, Student>
    {
        private readonly IStudentRepo _context;

        public GetByIdHandler(IStudentRepo context)
        {
            _context = context;
        }

        public async Task<Student> Handle(GetStudentQueryId request, CancellationToken cancellationToken)
        {
            return await _context.GetByID(request.Id);
        }
    }
}
