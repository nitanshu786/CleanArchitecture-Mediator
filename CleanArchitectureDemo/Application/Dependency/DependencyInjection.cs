using Application.Common.Behavior;
using Application.Interface.IRepository;
using Application.Interface.Repository;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dependency
{
   public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<IRegisterRepo, RegisterRepo>();
            services.AddScoped<IQuizRepo, QuizRepo>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
           

        }
    }
}
