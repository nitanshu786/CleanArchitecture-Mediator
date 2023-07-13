using Application.Interface;
using Domain.Entity;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Context
{
    public class ApplicationDbContext : DbContext, IApplicatinDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option):base(option)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<ExternalUser> ExternalUsers { get; set; }
        public DbSet<LoginUsers> LoginUsers { get; set; }
        public DbSet<Quizquestions> Quizquestions { get; set; }
        public DbSet<UserSelectedAnswer> UserSelectedAnswers { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public async Task<int> SaveChanges()
        {
            return  base.SaveChanges();
        }
    }
}
