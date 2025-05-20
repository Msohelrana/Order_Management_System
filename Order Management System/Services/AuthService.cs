using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Order_Management_System.data;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;
using Order_Management_System.Models;

namespace Order_Management_System.Services
{
    public class AuthService:IAuthService
    {
        private readonly AppDbContext _appDbContext;
         private readonly IMapper _mapper;

         public AuthService(AppDbContext appDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }


        //CreateCustomer method for Create a customer with data

        public async Task<CustomerReadDto> CreateCustomer(CustomerCreateDto customerData)
        {
            var foundCustomer =await _appDbContext.Customers.FirstOrDefaultAsync(c=>c.CustomerEmail== customerData.CustomerEmail);
            if (foundCustomer != null)
            {
                return null;
            }
            var newCustomer = _mapper.Map<Customer>(customerData);
            newCustomer.CustomerId = Guid.NewGuid();
            newCustomer.CreatedAt = DateTime.UtcNow;
            await _appDbContext.Customers.AddAsync(newCustomer);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<CustomerReadDto>(newCustomer);

        }

        //CustomerLogin method for control login of a customer
        public async Task<int> CustomerLogin(CustomerLoginDto customerLoginData)
        {
            var foundCustomer =await _appDbContext.Customers.FirstOrDefaultAsync(c => c.CustomerEmail == customerLoginData.CustomerEmail);
            if(foundCustomer == null)
            {
                return 1;
            }
            if(foundCustomer.CustomerPassword != customerLoginData.CustomerPassword)
            {
                return 2;
            }
            return 3;
        }
    }
}
