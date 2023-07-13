using Application.BaseServices.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ContextService
{
    public interface IApplicationDbContext
    {
        DbSet<Employe> Employes { get; set; }

        int SaveChanges();
       
    }
}
