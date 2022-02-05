using System;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailStore.Models;
using OnlineRetailStore.Models.Interfaces;

namespace OnlineRetailStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllOrders()
        {
            try
            {
                var products = _orderServices.GetOrderList();
                return Ok(products);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                var product = _orderServices.GetOrder(id);
                if (product != null)
                    return Ok(product);

                return NotFound("Order with id: " + id + " is not available");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddOrder(Order order)
        {
            try
            {
                var result = _orderServices.AddOrder(order);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult CancelOrder(int orderId)
        {
            try
            {
                var result = _orderServices.DeleteOrder(orderId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
