using Microsoft.AspNetCore.Mvc;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;
using Order_Management_System.Services;

namespace Order_Management_System.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //POST : create Customers
        [HttpPost("register")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDto customerData)
        {
            var customerReadDto =await _authService.CreateCustomer(customerData);
            if(customerReadDto== null)
            {
                return BadRequest(ApiResponse<object>.SuccessResponse(null, 400, "The email has been already registered!"));
            }
            return Created("v1/api/Customer/{newOrder.OrderId}", ApiResponse<CustomerReadDto>
            .SuccessResponse(customerReadDto, 201, "Customer Registered Successfully"));

        }
        //POST method for customer's login
        [HttpPost("login")]
        public async Task<IActionResult> CustomerLogin([FromBody] CustomerLoginDto customerLoginData)
        {
            var flag =await _authService.CustomerLogin(customerLoginData);
            if (flag == 1)
            {
                return NotFound(ApiResponse<object>.SuccessResponse(null, 404, "Please enter currect email address!"));
            }
            else if(flag == 2)
            {
                return NotFound(ApiResponse<object>.SuccessResponse(null, 404, "Please enter currect password!"));
            }
            else
            {
                return Ok(ApiResponse<object>.SuccessResponse(null, 200, "Login successfully!"));
            }
        }
    }
}
