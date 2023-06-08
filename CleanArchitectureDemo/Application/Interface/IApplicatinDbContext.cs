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
      
        Task<int> SaveChangesAsync();
    }
}
