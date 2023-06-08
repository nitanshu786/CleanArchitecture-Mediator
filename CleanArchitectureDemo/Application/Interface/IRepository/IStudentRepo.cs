using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Repository
{
   public interface IStudentRepo
    {
        Task<List<Student>> GetAllStudent();
        Task<Student> GetByID(int Id);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateSutudent(Student student);
        Task<int> DeleteStudent(int Id);
    }
}
