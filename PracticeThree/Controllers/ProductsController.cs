using Logic.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PracticeThree.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductManager _productManager;
        public ProductsController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_productManager.GetProducts());
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] Logic.Models.Product product)
        {
            return Ok(_productManager.CreateProduct(product));
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] Logic.Models.Product product)
        {
            return Ok(_productManager.UpdateProduct(product));
        }

        [HttpDelete]
        [Route("{productId}")]
        public IActionResult DeleteProduct(Guid productId)
        {
            return Ok(_productManager.DeleteProduct(productId));
        }
    }
}
