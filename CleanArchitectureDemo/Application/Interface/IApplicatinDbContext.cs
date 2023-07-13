using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
     public interface IApplicatinDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Register> Registers { get; set; }
        DbSet<ExternalUser> ExternalUsers { get; set; }
        DbSet<LoginUsers> LoginUsers { get; set; }
        DbSet<Quizquestions> Quizquestions { get; set; }
        DbSet<UserSelectedAnswer> UserSelectedAnswers { get; set; }
        DbSet<UserActivity> UserActivities { get; set; }
      
        Task<int> SaveChangesAsync();
        Task<int> SaveChanges();

    }
}
