using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order_Management_System.data;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;
using Order_Management_System.Models;

namespace Order_Management_System.Services
{
    public class CustomerService:ICustomerService
    {
        //public static readonly List<Customer> customers = new List<Customer>();
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CustomerService(AppDbContext appDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;

        }

        //GetAllCustomer method for get all customer

        public async Task<List<CustomerReadDto>> GetAllCustomer()
        {
            var customers =await _appDbContext.Customers.ToListAsync();
            return _mapper.Map<List<CustomerReadDto>>(customers);

        }

        //GetACustomer method for get a customer by Id

        public async Task<CustomerReadDto?> GetACustomer(Guid customerId)
        {
            var foundCustomer =await _appDbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            return foundCustomer == null ? null : _mapper.Map<CustomerReadDto>(foundCustomer);
        }

        //UpdateCustomer method for Update a customer by Id with data

        public async Task<bool> UpdateCustomer(Guid customerId, CustomerUpdateDto customerData)
        {
            var foundCustomer =await _appDbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if (foundCustomer == null) return false;
            _mapper.Map(customerData, foundCustomer);
            _appDbContext.Customers.Update(foundCustomer);
            return true;
        }

        //DeleteCustomer method for Delete a customer by Id

        public async Task<bool> DeleteCustomer(Guid customerId)
        {
            var foundCustomer =await _appDbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if (foundCustomer == null) return false;
            _appDbContext.Customers.Remove(foundCustomer);
            await _appDbContext.SaveChangesAsync();
            return true;


        }

    }
}

