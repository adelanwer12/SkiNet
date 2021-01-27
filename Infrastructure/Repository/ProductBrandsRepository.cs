using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProductBrandsRepository : IProductBrandsRepository
    {
        private readonly StoreContext _context;
        public ProductBrandsRepository(StoreContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.productBrands.ToListAsync();
        }
    }
}