﻿using Business.Abstracts;
using Business.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IApplicantService, ApplicantManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<IApplicationService, ApplicationManager>();
            services.AddScoped<IApplicationStateService, ApplicationStateManager>();
            services.AddScoped<IBootcampService, BootcampManager>();
            services.AddScoped<IBootcampStateService, BootcampStateManager>();

            return services;
        }
    }
}
