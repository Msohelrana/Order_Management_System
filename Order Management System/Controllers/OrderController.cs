using Microsoft.AspNetCore.Mvc;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;

namespace Order_Management_System.Controllers
{
    [ApiController]
    [Route("v1/api/orders/")]
    public class OrderController : ControllerBase
    {

        private IOrderService orderService;

        public OrderController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        //GET : read product

        [HttpGet]
        public IActionResult GetAllOrder()
        {
            var orderReadDto = orderService.GetAllOrder();
            return Ok(ApiResponse<List<OrderReadDto>>
           .SuccessResponse(orderReadDto, 200, "Orders Returned Successfully!"));
        }

        //GET method for getting a single product by Id
        [HttpGet("{orderId:guid}")]

        public IActionResult GetOrderById(Guid orderId)
        {
            var foundOrder = orderService.GetAOrder(orderId);
            if (foundOrder == null)
            {
                return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Order with this id does not exist!"));
            }
            return Ok(ApiResponse<OrderReadDto>.SuccessResponse(foundOrder, 200, "Order Returned Successfully!"));
        }

        //POST : create products
        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderCreateDto orderData)
        {
            var orderReadDto = orderService.CreateOrder(orderData);
            if (orderReadDto == null)
            {
                return BadRequest(ApiResponse<object>.SuccessResponse(null, 404, "This product is not available right now!"));
            }

            return Created("v1/api/orders/{newOrder.OrderId}", ApiResponse<OrderReadDto>
            .SuccessResponse(orderReadDto, 201, "Order Created Successfully"));

        }

        //PUT: Update product

        [HttpPut("{orderId:guid}")]

        public IActionResult UpdateOrder(Guid orderId, [FromBody] OrderUpdateDto orderData)
        {
            var isUpdate = orderService.UpdateOrder(orderId, orderData);
            if (isUpdate == false) return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Order with this id does not exist!"));

            return Ok(ApiResponse<object>
                .SuccessResponse(null, 200, "Order Updated Successfully"));

        }

        //DELETE:Delete a product
        [HttpDelete("{orderId:guid}")]

        public IActionResult Deleteorders(Guid orderId)
        {
            var isDelete = orderService.DeleteOrder(orderId);
            if (isDelete == false) return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Order with this id does not exist!"));

            return Ok(ApiResponse<object>
                 .SuccessResponse(null, 200, "Order Deleted Successfully"));

        }




    }
}
