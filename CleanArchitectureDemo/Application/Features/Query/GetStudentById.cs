using Application.Interface.Repository;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Query
{
   public class GetStudentById : IRequest<Student>
    {
        public GetStudentById(int ID)
        {
            Id = ID;
        }
        public int Id { get; set; }
    }

    public class GetByIdHandler : IRequestHandler<GetStudentById, Student>
    {
        private readonly IStudentRepo _context;

        public GetByIdHandler(IStudentRepo context)
        {
            _context = context;
        }

        public async Task<Student> Handle(GetStudentById request, CancellationToken cancellationToken)
        {
            return await _context.GetByID(request.Id);
        }
    }
}
