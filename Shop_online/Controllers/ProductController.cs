
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shop_online.Interfaces;
using Shop_online.Model;

namespace Shop_online.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly productInterface _productRepo;

        public ProductController(productInterface productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepo.GetProduct();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productRepo.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                product_id = productDto.product_id,
                product_name = productDto.product_name,
                product_price = productDto.product_price,
                product_quantity =productDto.product_quantity,
                product_details = productDto.product_details,
                product_photo = productDto.product_photo
            };

            _productRepo.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.p_id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductDto productDto)
        {
            var existingProduct = _productRepo.GetProduct(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingProduct.product_id = productDto.product_id;
            existingProduct.product_name = productDto.product_name;
            existingProduct.product_price = productDto.product_price;
            existingProduct.product_quantity =productDto.product_quantity;
            existingProduct.product_details = productDto.product_details;
            existingProduct.product_photo = productDto.product_photo;

            _productRepo.UpdateProduct(existingProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = _productRepo.GetProduct(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            _productRepo.DeleteProduct(existingProduct);
            return NoContent();
        }
    }
}
