using Application.BaseServices.Repository;
using Application.BaseServices.Repository.IRepsitory;
using Domain.Entity;
using InfraStructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data.DependencyService
{
    public class UnitService : IUnitService
    {
        private readonly ApplicationDbContext _context;

        public UnitService(ApplicationDbContext context)
        {
            _context = context;
            employee = new EmployeRepository(_context);
        }

        public IEmployeeRepository employee { get; set; }

        public int Save()
        {
           return _context.SaveChanges();   
        }
    }
}
