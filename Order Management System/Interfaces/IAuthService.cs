using Order_Management_System.DTOs;

namespace Order_Management_System.Interfaces
{
    public interface IAuthService
    {
        Task<CustomerReadDto> CreateCustomer(CustomerCreateDto customerData);
        Task<int> CustomerLogin(CustomerLoginDto customerLoginData);
    }
}
