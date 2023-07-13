using MiddlewareProject.Model;

namespace MiddlewareProject.Interface.IRepository
{
    public interface IStudentRepo
    {
        Task<List<Student>> GetAllStudent();
        Task<Student> GetByID(int Id);
        Student CreateStudent(Student student);
        Task<Student> UpdateSutudent(Student student);
        Task<int> DeleteStudent(int Id);
      
    }
}
