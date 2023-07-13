using MediatR;
using MiddlewareProject.Interface.IRepository;
using MiddlewareProject.Model;

namespace MiddlewareProject.Querys
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
