using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProductTypesRepository : IProductTypesRepository
    {
        private readonly StoreContext _context;
        public ProductTypesRepository(StoreContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            return await _context.productTypes.ToListAsync();
        }
    }
}