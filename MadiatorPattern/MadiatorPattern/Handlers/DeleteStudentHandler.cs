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
    public class DeleteStudentHandler : IRequestHandler<DeleteCommand, int>
    {
        private readonly IStudentRepo _context;

        public DeleteStudentHandler(IStudentRepo context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return await _context.DeleteStudent(request.Id);
        }
    }
}
