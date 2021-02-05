using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("seeddata")]
    public class SeedDatatController : ControllerBase
    {
        private readonly StoreContext _context;
        public SeedDatatController(StoreContext context)
        {
            _context = context;

        }

        [HttpPost("brands")]
        public IActionResult PostBrands(ProductBrand[] brands)
        {
            foreach (var brand in brands)
            {
                _context.productBrands.Add(brand);
            }
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost("types")]
        public IActionResult PostTypes(ProductType[] types)
        {
            foreach (var type in types)
            {
                _context.productTypes.Add(type);
            }
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPost("product")]
        public IActionResult Postproducts(Product[] products)
        {
            foreach (var product in products)
            {
                _context.Products.Add(product);
            }
            _context.SaveChanges();
            return NoContent();
        }
    }
}