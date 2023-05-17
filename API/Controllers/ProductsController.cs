using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Core.Interfaces;
using Core.Specifications;
using API.DTOs;
using API.Errors;
using API.Helpers;

namespace API.Controllers
{

    public class ProductsController : BaseAPIController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper)
        {
            this._productsRepo = productRepo;
            this._productBrandRepo = productBrandRepo;
            this._productTypeRepo = productTypeRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductReturnDTO>>> GetProducts([FromQuery] ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithTypesandBrandsSpecification(productSpecParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);
            var totalItems = await _productsRepo.CountAsync(countSpec);
            var products = await _productsRepo.ListAsync(spec);
            var productsDTO = _mapper.Map<IReadOnlyList<ProductReturnDTO>>(products);
            return Ok(new Pagination<ProductReturnDTO>(productSpecParams.PageIndex, productSpecParams.PageSize, totalItems, productsDTO));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesandBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            if (product == null)
                return NotFound(new ApiErrorResponse(404));

            var productDTO = _mapper.Map<ProductReturnDTO>(product);
            return Ok(productDTO);
        }

        [HttpGet]
        [Route("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await this._productBrandRepo.ListAllAsync());
        }

        [HttpGet]
        [Route("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await this._productBrandRepo.ListAllAsync());
        }
    }
}
