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
    public class UpdateStudentCommand : IRequest<Student>
    {
        public UpdateStudentCommand(Student student)
        {

            ID = student.Id;
            Name = student.Name;
            Address = student.Address;
            Email = student.Email;
            Contact = student.Contact;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

    }

    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly IStudentRepo _context;

        public UpdateStudentHandler(IStudentRepo context)
        {
            _context = context;
        }

        public async Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {

            Student student = new Student()
            {
                Id = request.ID,
                Name = request.Name,
                Address = request.Address,
                Email = request.Email,
                Contact = request.Contact
            };
            return await _context.UpdateSutudent(student);
        }
    }
}
