using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Helpers;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(Guid id);
        Task<PagedList<Product>> GetProductsAsync(ResourceParameters parameters);
    }
}