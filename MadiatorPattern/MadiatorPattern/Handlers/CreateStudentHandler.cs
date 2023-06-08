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
    public class CreateStudentHandler : IRequestHandler<CreateCommand, Student>
    {
        private readonly IStudentRepo _context;

        public CreateStudentHandler(IStudentRepo context)
        {
            _context = context;
        }

        public async Task<Student> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            Student student = new Student()
            {
                Name = request.Name,
                Address = request.Address,
                Age = request.Age
            };
            return await _context.CreateStudent(student);
        }
    }
}
