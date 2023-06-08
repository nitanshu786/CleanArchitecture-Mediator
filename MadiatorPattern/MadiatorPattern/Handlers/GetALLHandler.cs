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
    public class GetALLHandler : IRequestHandler<GetStudentQuery, List<Student>>
    {
        private readonly IStudentRepo _Context;

        public GetALLHandler(IStudentRepo context)
        {
            _Context = context;
        }

        public async Task<List<Student>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            return await _Context.GetAllStudent();
        }
    }
}
