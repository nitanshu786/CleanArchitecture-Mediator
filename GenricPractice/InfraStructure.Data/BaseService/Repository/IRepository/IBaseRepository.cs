using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data.BaseService.Repository.IRepository
{
    public interface IBaseRepository<t> where t : class
    {
        Task<IEnumerable<t>> GetAll { get; }
        Task<t> FindById(Guid id);  
        void Add(t entity);
        void Update(t entity);
        void Delete(t entity);
    }
}
