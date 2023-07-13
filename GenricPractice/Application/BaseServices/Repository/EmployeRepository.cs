using Application.BaseServices.Repository.IRepsitory;
using Application.ContextService;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BaseServices.Repository
{
    public class EmployeRepository:BaseRepository<Employe>,IEmployeeRepository
    {
        private readonly IApplicationDbContext _context;
        public EmployeRepository(IApplicationDbContext context):base(context) 
        {
               _context=context;
        }
       
    }
}
