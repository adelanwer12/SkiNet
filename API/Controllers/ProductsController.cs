using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController, Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PaginationList<ProductToReturn>>>> GetProducts([FromQuery] ResourceParameters parameters)
        {
            var products = await _productRepo.GetProductsAsync(parameters);
            var productsToReturn = _mapper.Map<IReadOnlyList<ProductToReturn>>(products);
            return Ok(new PaginationList<ProductToReturn>{PageSize = parameters.PageSize, PageNumber = parameters.PageNumber, ProductsCount = products.TotalCount, Data = productsToReturn});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<ProductToReturn>>> GetProduct(Guid id)
        {
            var product = await _productRepo.GetProductByIdAsync(id);
            var productToReturn = _mapper.Map<ProductToReturn>(product);
            return Ok(productToReturn);
        }
    }
}