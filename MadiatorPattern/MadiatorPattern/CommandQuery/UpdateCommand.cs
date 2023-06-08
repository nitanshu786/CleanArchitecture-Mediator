using MadiatorPattern.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadiatorPattern.CommandQuery
{
    public class UpdateCommand:IRequest<Student>
    {
        public UpdateCommand(Student student)
        {

            ID = student.ID;
            Name = student.Name;
            Address = student.Address;
            Age = student.Age;
        }
        public int ID { get; set; }
        public string Name  { get; set; }
        public string Address  { get; set; }
        public int Age  { get; set; }
  
    }
}
