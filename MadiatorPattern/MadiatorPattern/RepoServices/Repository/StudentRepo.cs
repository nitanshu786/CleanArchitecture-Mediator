using MadiatorPattern.Data;
using MadiatorPattern.Model;
using MadiatorPattern.RepoServices.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadiatorPattern.RepoServices.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDbcontext _Context;

        public StudentRepo(ApplicationDbcontext context)
        {
            _Context = context;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            if(student!=null)
            {
                var create = _Context.Students.Add(student);
                await _Context.SaveChangesAsync();
                return create.Entity;
            }
            return null;
        }

        public async Task<int> DeleteStudent(int Id)
        {
            var find = _Context.Students.FindAsync(Id);
            if (await find != null)
            {
                _Context.Students.Remove(await find);
               return await _Context.SaveChangesAsync();
               
            }
            return 0;
        }

        public async Task<List<Student>> GetAllStudent()
        {
            var allStudents = await _Context.Students.ToListAsync();
            return allStudents;
        }

        public async Task<Student> GetByID(int Id)
        {
            if(Id!=0)
            {
                var finds = await _Context.Students.FindAsync(Id);
                if (finds == null)
                  return null;
                  return finds;
            }
            return null;
        }

        public  async Task<Student> UpdateSutudent(Student student)
        {
           if(student!=null)
            {
                var update = _Context.Students.Update(student);
                await _Context.SaveChangesAsync();
                return update.Entity;
            }
            return null;
        }
    }
}
