using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order_Management_System.data;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;
using Order_Management_System.Models;

namespace Order_Management_System.Services
{
    public class OrderService:IOrderService
    {
        //private static readonly List<Order> orders = new List<Order>();
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public OrderService(AppDbContext appContext, IMapper mapper)
        {
            _mapper = mapper;
            _appDbContext = appContext;
             
        }

        //GetAllOrder method for get all order

        public async Task<List<OrderReadDto>> GetAllOrder()
        {
            var order = await _appDbContext.Orders.ToListAsync();
            return _mapper.Map<List<OrderReadDto>>(order);

        }

        //GetAOrder method for get a order by Id

        public async Task<OrderReadDto?> GetAOrder(Guid orderId)
        {
            var foundOrder = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            return foundOrder == null ? null : _mapper.Map<OrderReadDto>(foundOrder);
        }

        //CreateOrder method for Create a order with data

        public async Task<OrderReadDto> CreateOrder(OrderCreateDto orderData)
        {
            if (!_appDbContext.Products.Any())
            {
                return null;
            }
            var foundProduct =await _appDbContext.Products.FirstOrDefaultAsync(p=> p.ProductId==orderData.ProductId);
            if(foundProduct.Quantity<=0)
            {
                return null;
            }
            var newOrder = _mapper.Map<Order>(orderData);
            newOrder.OrderId = Guid.NewGuid();
            newOrder.OrderDate = DateTime.UtcNow;
            newOrder.ProductName = foundProduct.ProductName;
            newOrder.TotalPrice = orderData.Quantity*foundProduct.Price;
            foundProduct.Quantity -= orderData.Quantity;
            await _appDbContext.Orders.AddAsync(newOrder);
            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<OrderReadDto>(newOrder);

        }

        //UpdateOrder method for Update a order by Id with data

        public async Task<bool> UpdateOrder(Guid orderId, OrderUpdateDto orderData)
        {
            var foundOrder =await _appDbContext.Orders.FirstOrDefaultAsync(o=> o.OrderId == orderId);
            if (foundOrder == null) return false;
            _mapper.Map(orderData, foundOrder);
            _appDbContext.Orders.Update(foundOrder);
            return true;
        }

        //DeleteOrder method for Delete a order by Id

        public async Task<bool> DeleteOrder(Guid orderId)
        {
            var foundOrder =await _appDbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (foundOrder == null) return false;
            _appDbContext.Orders.Remove(foundOrder);
            await _appDbContext.SaveChangesAsync();
            return true;


        }

    }
}

