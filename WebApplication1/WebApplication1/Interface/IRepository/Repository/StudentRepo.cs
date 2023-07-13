using Microsoft.EntityFrameworkCore;
using MiddlewareProject.DBContext;
using MiddlewareProject.Model;

namespace MiddlewareProject.Interface.IRepository.Repository
{
    public class StudentRepo:IStudentRepo
    {
        private readonly ApplicationDbContext _context;

        public StudentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Student CreateStudent(Student student)
        {
            if (student != null)
            {
                var create = _context.Students.Add(student);
                _context.SaveChanges();
                return create.Entity;
            }
            return null;
        }

        public async Task<int> DeleteStudent(int Id)
        {
            var find = _context.Students.FindAsync(Id);
            if (await find != null)
            {
                _context.Students.Remove(await find);
                return await _context.SaveChangesAsync();

            }
            return 0;
        }

        public async Task<List<Student>> GetAllStudent()
        {
            var allStudents = await _context.Students.ToListAsync();
            return allStudents;
        }

        public async Task<Student> GetByID(int Id)
        {
            if (Id != 0)
            {
                var finds = await _context.Students.FindAsync(Id);
                if (finds == null)
                    return null;
                return finds;
            }
            return null;
        }

        public async Task<Student> UpdateSutudent(Student student)
        {
            if (student != null)
            {
                var update = _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return update.Entity;
            }
            return null;
        }
    }
}
