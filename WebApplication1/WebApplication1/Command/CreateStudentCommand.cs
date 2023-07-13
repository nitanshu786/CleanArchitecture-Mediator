using MediatR;
using MiddlewareProject.Interface.IRepository;
using MiddlewareProject.Model;

namespace MiddlewareProject.Command
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public CreateStudentCommand(Student student)
        {
            Name = student.Name;
            Address = student.Address;
            Contact = student.Contact;
        }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
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
                Contact = request.Contact
            };
            var newone = _context.CreateStudent(student);
            return newone;
        }


    }
}
