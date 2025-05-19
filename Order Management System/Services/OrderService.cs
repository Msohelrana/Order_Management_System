using AutoMapper;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;
using Order_Management_System.Models;

namespace Order_Management_System.Services
{
    public class OrderService:IOrderService
    {
        private static readonly List<Order> orders = new List<Order>();
        private readonly IMapper mapper;

        public OrderService(IMapper mapper)
        {
            this.mapper = mapper;
             
        }

        //GetAllProduct method for get all product

        public List<OrderReadDto> GetAllOrder()
        {
            return mapper.Map<List<OrderReadDto>>(orders);

        }

        //GetAProduct method for get a product by Id

        public OrderReadDto? GetAOrder(Guid orderId)
        {
            var foundOrder = orders.FirstOrDefault(o => o.OrderId == orderId);
            return foundOrder == null ? null : mapper.Map<OrderReadDto>(foundOrder);
        }

        //CreateProduct method for Create a product with data

        public OrderReadDto CreateOrder(OrderCreateDto orderData)
        {
            if (ProductService.products.Count <= 0)
            {
                return null;
            }
            var foundProduct = ProductService.products.FirstOrDefault(p=> p.ProductId==orderData.ProductId);
            if(foundProduct.Quantity<=0)
            {
                return null;
            }
            var newOrder = mapper.Map<Order>(orderData);
            newOrder.OrderId = Guid.NewGuid();
            newOrder.OrderDate = DateTime.UtcNow;
            newOrder.ProductName = foundProduct.ProductName;
            newOrder.TotalPrice = orderData.Quantity*foundProduct.Price;
            foundProduct.Quantity -= orderData.Quantity;
            orders.Add(newOrder);

            return mapper.Map<OrderReadDto>(newOrder);

        }

        //UpdateProduct method for Update a product by Id with data

        public bool UpdateOrder(Guid orderId, OrderUpdateDto orderData)
        {
            var foundOrder = orders.FirstOrDefault(o=> o.OrderId == orderId);
            if (foundOrder == null) return false;
            mapper.Map(orderData, foundOrder);
            return true;
        }

        //DeleteProduct method for Delete a product by Id

        public bool DeleteOrder(Guid orderId)
        {
            var foundOrder = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (foundOrder == null) return false;
            orders.Remove(foundOrder);
            return true;


        }

    }
}

