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
    public class DeleteStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepo _context;

        public DeleteStudentHandler(IStudentRepo context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _context.DeleteStudent(request.Id);
        }
    }
}
