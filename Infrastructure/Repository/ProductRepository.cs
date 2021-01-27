using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
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

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(t =>t.ProductType).Include(b =>b.ProductBrand).ToListAsync();
        }
    }
}