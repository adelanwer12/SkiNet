using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;

        }
        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.Include(t =>t.ProductType).Include(b =>b.ProductBrand).SingleOrDefaultAsync(p =>p.Id == id);
        }

        public async Task<PagedList<Product>> GetProductsAsync(ResourceParameters parameters)
        {
            var products = _context.Products
                .Include(t => t.ProductType)
                .Include(b => b.ProductBrand) as IQueryable<Product>;
            
            if (!string.IsNullOrWhiteSpace(parameters.Sort))
            {
                products = parameters.Sort.Trim() switch
                {
                    "priceAsc" => products.OrderBy(p => p.Price),
                    "priceDesc" => products.OrderByDescending(p => p.Price),
                    _ => products.OrderBy(p => p.Name)
                };
            }

            if (!string.IsNullOrWhiteSpace(parameters.ProductBrand) && parameters.ProductBrand != "All")
            {
                var productBrand = parameters.ProductBrand.Trim();
                products = products.Where(p => p.ProductBrand.Name == productBrand);
            }

            if (!string.IsNullOrWhiteSpace(parameters.ProductType) && parameters.ProductType != "All")
            {
                var productType = parameters.ProductType.Trim();
                products = products.Where(p => p.ProductType.Name == productType);
            }
            if (!string.IsNullOrWhiteSpace(parameters.Search))
            {
                var productSearch = parameters.Search.Trim().ToLowerInvariant();
                products = products.Where(p => 
                    p.Name.Contains(productSearch) || 
                    p.ProductBrand.Name.Contains(productSearch) || 
                    p.ProductType.Name.Contains(productSearch));
            }

            return await PagedList<Product>.CreateAsync(products, parameters.PageNumber, parameters.PageSize);
        }
    }
}