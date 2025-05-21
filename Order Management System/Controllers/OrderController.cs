using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_Management_System.data;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;

namespace Order_Management_System.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class OrderController : ControllerBase
    {

        private IOrderService _orderService;
        private readonly AppDbContext _appDbContext;

        public OrderController(AppDbContext appDbContext,IOrderService orderService)
        {
            _orderService = orderService;
            _appDbContext = appDbContext;
        }

        //GET : read order

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var orderReadDto =await _orderService.GetAllOrder();
            return Ok(ApiResponse<List<OrderReadDto>>
           .SuccessResponse(orderReadDto, 200, "Orders Returned Successfully!"));
        }

        //GET method for getting a single order by Id
        [HttpGet("{orderId:guid}")]

        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            var foundOrder =await _orderService.GetAOrder(orderId);
            if (foundOrder == null)
            {
                return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Order with this id does not exist!"));
            }
            return Ok(ApiResponse<OrderReadDto>.SuccessResponse(foundOrder, 200, "Order Returned Successfully!"));
        }

        //POST : create orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderData)
        {
            var customer = await _appDbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == orderData.CustomerId);
            if(customer == null)
            {
                return BadRequest(ApiResponse<object>.SuccessResponse(null, 400, "You are not register yet!Please register to order a product!"));
            }
            var orderReadDto =await _orderService.CreateOrder(orderData);
            if (orderReadDto == null)
            {
                return NotFound(ApiResponse<object>.SuccessResponse(null, 404, "This product is not available right now!"));
            }

            return Created("v1/api/orders/{newOrder.OrderId}", ApiResponse<OrderReadDto>
            .SuccessResponse(orderReadDto, 201, "Order Created Successfully"));

        }

        //PUT: Update order

        [HttpPut("{orderId:guid}")]

        public async Task<IActionResult> UpdateOrder(Guid orderId, [FromBody] OrderUpdateDto orderData)
        {
            var updateValue =await _orderService.UpdateOrder(orderId, orderData);
            if (updateValue == 1) return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Product with this id does not exist!"));
            else if(updateValue == 2) return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Order with this id does not exist!"));

            return Ok(ApiResponse<object>
                    .SuccessResponse(null, 200, "Order Updated Successfully"));

        }

        //DELETE:Delete a order
        [HttpDelete("{orderId:guid}")]

        public async Task<IActionResult> Deleteorders(Guid orderId)
        {
            var isDelete =await _orderService.DeleteOrder(orderId);
            if (isDelete == false) return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Order with this id does not exist!"));

            return Ok(ApiResponse<object>
                 .SuccessResponse(null, 200, "Order Deleted Successfully"));

        }




    }
}
