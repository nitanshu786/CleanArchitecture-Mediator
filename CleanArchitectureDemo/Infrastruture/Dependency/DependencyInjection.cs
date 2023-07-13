using Application.Interface;
using Infrastruture.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Dependency
{
   public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services)
        {
          
            services.AddTransient<IApplicatinDbContext>(provider => provider.GetService<ApplicationDbContext>());
        }
    }
}
