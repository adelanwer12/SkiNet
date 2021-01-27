using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, Route("api/brands")]
    public class BrandsController : ControllerBase
    {
        private readonly IProductBrandsRepository _BrandsRepo;
        public BrandsController(IProductBrandsRepository BrandsRepo)
        {
            _BrandsRepo = BrandsRepo;

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productPrands = await _BrandsRepo.GetProductBrandsAsync();
            return Ok(productPrands);
        }
    }
}