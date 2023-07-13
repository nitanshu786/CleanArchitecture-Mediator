using Application.Interface.IRepository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly IApplicatinDbContext _context;


        public StudentRepo(IApplicatinDbContext context)
        {
            _context = context;

        }

        public Student CreateStudent(Student student)
        {
            if (student != null)
            {
                var create =  _context.Students.Add(student);
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

        public bool ExtractEmailFromToken(string jwtToken)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);
            var emailClaim = token.Claims.FirstOrDefault(c => c.Type == "email");
            var email = emailClaim?.Value;
            if (email != null)
            {
                var finds = _context.LoginUsers.FirstOrDefault(x => x.SessionId == email);
                if (finds != null)
                    return true;
                return false;
            }
            return false;
        }
    }
}
