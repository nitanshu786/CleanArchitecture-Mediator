using Application.BaseServices.Repository.IRepsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data.DependencyService
{
    public interface IUnitService
    {
        IEmployeeRepository employee { get; }
        int Save();
    }
}
