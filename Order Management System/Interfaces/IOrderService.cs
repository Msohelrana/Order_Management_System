using Order_Management_System.DTOs;

namespace Order_Management_System.Interfaces
{
    public interface IOrderService
    {
        List<OrderReadDto> GetAllOrder();
        OrderReadDto? GetAOrder(Guid orderId);
        OrderReadDto CreateOrder(OrderCreateDto orderData);
        bool UpdateOrder(Guid orderId, OrderUpdateDto orderData);
        bool DeleteOrder(Guid orderId);
    }
}
