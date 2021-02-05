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
        private readonly IProductBrandsRepository _brandsRepo;

        public BrandsController(IProductBrandsRepository brandsRepo)
        {
            _brandsRepo = brandsRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _brandsRepo.GetProductBrandsAsync();
            return Ok(productBrands);
        }
    }
}