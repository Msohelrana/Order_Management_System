using Microsoft.AspNetCore.Mvc;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;

namespace Order_Management_System.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class CustomerController:ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //GET : read customers

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customerReadDto =await _customerService.GetAllCustomer();
            return Ok(ApiResponse<List<CustomerReadDto>>
           .SuccessResponse(customerReadDto, 200, "Customers Returned Successfully!"));
        }

        //GET method for getting a single customer by Id
        [HttpGet("{customerId:guid}")]

        public async Task<IActionResult> GetCustomerById(Guid customerId)
        {
            var foundCustomer =await _customerService.GetACustomer(customerId);
            if (foundCustomer == null)
            {
                return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Customer with this id does not exist!"));
            }
            return Ok(ApiResponse<CustomerReadDto>.SuccessResponse(foundCustomer, 200, "Customer Returned Successfully!"));
        }

        //PUT: Update customer

        [HttpPut("{customerId:guid}")]

        public async Task<IActionResult> UpdateCustomer(Guid customerId, [FromBody] CustomerUpdateDto customerData)
        {
            var isUpdate =await _customerService.UpdateCustomer(customerId, customerData);
            if (isUpdate == false) return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Customer with this id does not exist!"));

            return Ok(ApiResponse<object>
                .SuccessResponse(null, 200, "Customer Updated Successfully"));

        }

        //DELETE:Delete a customer
        [HttpDelete("{customerId:guid}")]

        public async Task<IActionResult> DeleteCustomers(Guid customerId)
        {
            var isDelete =await _customerService.DeleteCustomer(customerId);
            if (isDelete == false) return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Customer with this id does not exist!"));

            return Ok(ApiResponse<object>
                 .SuccessResponse(null, 200, "Customer Deleted Successfully!"));

        }
    }
}
