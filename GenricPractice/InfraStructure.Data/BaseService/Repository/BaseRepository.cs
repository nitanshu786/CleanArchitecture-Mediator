
using InfraStructure.Data.BaseService.Repository.IRepository;
using InfraStructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data.BaseService.Repository
{
    public class BaseRepository<t> : IBaseRepository<t> where t : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<t> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet= _context.Set<t>();  
        }

        void IBaseRepository<t>.Add(t entity)=> _dbSet.Add(entity);
       
        void IBaseRepository<t>.Delete(t entity)=> _dbSet.Remove(entity);
        
        async Task<t> IBaseRepository<t>.FindById(Guid id) => await _dbSet.FindAsync(id);

        Task<IEnumerable<t>> IBaseRepository<t>.GetAll => (Task<IEnumerable<t>>)_dbSet.AsAsyncEnumerable();

        void IBaseRepository<t>.Update(t entity) => _dbSet.Update(entity);
    }
}
