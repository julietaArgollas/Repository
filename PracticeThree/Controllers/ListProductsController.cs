using Logic.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PracticeThree.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ListProductsController : ControllerBase
    {
        private ListProductsManager _listProductManager;
        public ListProductsController(ListProductsManager listProductsManager)
        {
            _listProductManager = listProductsManager;
        }

        [HttpGet]
        public IActionResult GetListProducts()
        {
            return Ok(_listProductManager.GetListProducts());
        }

        [HttpGet]
        [Route("activeCampaign")]
        public IActionResult GetCampaign()
        {
            return Ok(_listProductManager.GetActiveCampaign());
        }

        [HttpPost]
        public IActionResult CreateList([FromBody] Logic.Models.ListProducts listProduct)
        {
            return Ok(_listProductManager.CreateList(listProduct));
        }

        [HttpPut]
        public IActionResult UpdateList([FromBody] Logic.Models.ListProducts listProducts)
        {
            return Ok(_listProductManager.UpdateListProduct(listProducts));
        }

        [HttpDelete]
        [Route("{listId}")]
        public IActionResult DeleteProduct(Guid listId)
        {
            return Ok(_listProductManager.DeleteList(listId));
        }
    }
}
