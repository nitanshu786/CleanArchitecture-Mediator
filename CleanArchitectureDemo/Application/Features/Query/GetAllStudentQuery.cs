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
    public class GetAllStudentQuery : IRequest<List<Student>>
    {
    }
    public class GetALLHandler : IRequestHandler<GetAllStudentQuery, List<Student>>
    {
        private readonly IStudentRepo _Context;

        public GetALLHandler(IStudentRepo context)
        {
            _Context = context;
        }

        public async Task<List<Student>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            return await _Context.GetAllStudent();
        }
    }
}
