using Order_Management_System.DTOs;

namespace Order_Management_System.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerReadDto>> GetAllCustomer();
        Task<CustomerReadDto?> GetACustomer(Guid customerId);
        Task<bool> UpdateCustomer(Guid customerId, CustomerUpdateDto customerData);
        Task<bool> DeleteCustomer(Guid customerId);
    }
}
