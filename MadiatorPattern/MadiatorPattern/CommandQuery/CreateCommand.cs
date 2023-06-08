using MadiatorPattern.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadiatorPattern.CommandQuery
{
    public class CreateCommand:IRequest<Student>
    {
        public CreateCommand(Student student)
        {
            Name = student.Name;
            Address = student.Address;
            Age = student.Age;
        }
            public string Name { get; set; }
            public string Address { get; set; }
            public int Age { get; set; }
    }
  }
