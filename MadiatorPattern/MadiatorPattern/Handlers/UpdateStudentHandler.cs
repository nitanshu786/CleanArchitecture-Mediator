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
    public class UpdateStudentHandler : IRequestHandler<UpdateCommand, Student>
    {
        private readonly IStudentRepo _context;

        public UpdateStudentHandler(IStudentRepo context)
        {
            _context = context;
        }

        public async Task<Student> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
          
                Student student = new Student()
                {
                    ID = request.ID,
                    Name = request.Name,
                    Address = request.Address,
                    Age = request.Age
                };
                return await _context.UpdateSutudent(student);
        }
    }
}
