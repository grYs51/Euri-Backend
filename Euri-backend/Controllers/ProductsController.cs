using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Euri_backend.Data;
using Euri_backend.Data.Dto;
using Euri_backend.Data.Models;
using Euri_backend.Repository;
using Euri_backend.Repository.Interfaces;
using Euri_backend.Utillities;
using Newtonsoft.Json;

namespace Euri_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery] ProductParameters parameters)

        {
            var products = await _repository.GetAllProducts(parameters);
            var productDtos = products.Select(product => new ProductDto(product));

            var metadata = new MetadataDto<ProductModel>(products);
            
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        
            return Ok(productDtos);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductModel(int id)
        {
            var product = await _repository.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(new ProductDto(product));
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> PutProductModel(int id, UpdateProductDto productModel)
        {
            if (id != productModel.Id)
            {
                return BadRequest();
            }

            var newProduct = await _repository.UpdateProduct(productModel.ToProductModel());

            if(newProduct == null)
            {
                return NotFound();
            }       

            return Ok(new ProductDto(newProduct));
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProductModel(CreateProductDto productModel)
        {
            var productEntity = await _repository.CreateProduct(productModel.ToProductModel());  

            return CreatedAtAction("GetProductModel", new { id = productEntity.Id }, new ProductDto(productEntity));
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductModel(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            
            var productModel = await _repository.DeleteProduct(id);
            if (productModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
