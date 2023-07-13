using Microsoft.EntityFrameworkCore;
using MiddlewareProject.Model;

namespace MiddlewareProject.DBContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {

        }

        public DbSet<Register> Registers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<LoginUsers> Users { get; set; }  
        public DbSet<UserActivity> Activitys { get; set; }  
    }
}
