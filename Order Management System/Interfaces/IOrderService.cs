using Order_Management_System.DTOs;

namespace Order_Management_System.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderReadDto>> GetAllOrder();
        Task<OrderReadDto?> GetAOrder(Guid orderId);
        Task<OrderReadDto> CreateOrder(OrderCreateDto orderData);
        Task<int> UpdateOrder(Guid orderId, OrderUpdateDto orderData);
        Task<bool> DeleteOrder(Guid orderId);
    }
}
