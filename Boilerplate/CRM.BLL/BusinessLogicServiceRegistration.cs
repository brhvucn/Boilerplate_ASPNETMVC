using CRM.BLL.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
    //This class registers the dependency injection for this layer
    public static class BusinessLogicServiceRegistration
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {            
            services.AddScoped<ICompanyFacade, CompanyFacade>();            
            return services;
        }
    }
}
