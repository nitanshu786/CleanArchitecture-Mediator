using Application.Interface.Repository;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Command
{
   public class CreateStudentCommand : IRequest<Student>
    {
        public CreateStudentCommand(Student student)
        {
            Name = student.Name;
            Address = student.Address;
            Email = student.Email;
            Contact = student.Contact;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }

    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IStudentRepo _context;

        public CreateStudentHandler(IStudentRepo context)
        {
            _context = context;
        }

        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = new Student()
            {
                Name = request.Name,
                Address = request.Address,
                Email = request.Email,
                Contact=request.Contact
            };
            return await _context.CreateStudent(student);
        }

       
    }

}
