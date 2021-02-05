using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController, Route("api/types")]
    public class TypesController : ControllerBase
    {
        private readonly IProductTypesRepository _typesRepo;
        public TypesController(IProductTypesRepository typesRepo)
        {
            _typesRepo = typesRepo;

        }
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            var productTypes = await _typesRepo.GetProductTypesAsync();
            return Ok(productTypes);
        }
    }
}