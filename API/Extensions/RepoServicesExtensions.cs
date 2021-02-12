using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class RepoServicesExtensions
    {
        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductBrandsRepository, ProductBrandsRepository>();
            services.AddScoped<IProductTypesRepository, ProductTypesRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            return services;
        }
    }
}
