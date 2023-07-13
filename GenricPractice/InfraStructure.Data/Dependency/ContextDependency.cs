using Application.ContextService;
using InfraStructure.Data.Context;
using InfraStructure.Data.DependencyService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Data.Dependency
{
    public static class ContextDependency
    {
        public static void  AddPrisistence(this IServiceCollection services)
        {
            services.AddTransient<IApplicationDbContext>(Provider=> Provider.GetService<ApplicationDbContext>());
            services.AddTransient<IUnitService, UnitService>();
            
        }
    }
}
