using System;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailStore.Models;
using OnlineRetailStore.Models.Interfaces;

namespace OnlineRetailStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productServices.GetProductList();
                return Ok(products);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _productServices.GetProduct(id);
                if (product != null)
                    return Ok(product);

                return NotFound("Product with id: " + id + " is not available");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                var result = _productServices.AddProduct(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                var result = _productServices.UpdateProduct(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                var result = _productServices.DeleteProduct(productId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
