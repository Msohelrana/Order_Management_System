using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order_Management_System.data;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;
using Order_Management_System.Models;

namespace Order_Management_System.Services
{
    public class ProductService:IProductService
    {
        //public static readonly List<Product> products = new List<Product>();

        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext appDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }
        //GetAllProduct method for get all product

        public async Task<List<ProductReadDto>> GetAllProduct()
        {
            var products = await _appDbContext.Products.ToListAsync();
            return _mapper.Map<List<ProductReadDto>>(products);

        }

        //GetAProduct method for get a product by Id

        public async Task<ProductReadDto?> GetAProduct(Guid productId)
        {
            var foundProduct = await _appDbContext.Products.FirstOrDefaultAsync(c => c.ProductId == productId);
            return foundProduct == null ? null : _mapper.Map<ProductReadDto>(foundProduct);
        }

        //CreateProduct method for Create a product with data

        public async Task<ProductReadDto> CreateProduct(ProductCreateDto productData)
        {
            var newProduct = _mapper.Map<Product>(productData);
            newProduct.ProductId = Guid.NewGuid();
            newProduct.CreatedAt = DateTime.UtcNow;
            await _appDbContext.Products.AddAsync(newProduct);
            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<ProductReadDto>(newProduct);

        }

        //UpdateProduct method for Update a product by Id with data

        public async Task<bool> UpdateProduct(Guid productId, ProductUpdateDto productData)
        {
            var foundProduct =await _appDbContext.Products.FirstOrDefaultAsync(p => !string.IsNullOrEmpty(p.ProductName)  && p.ProductId == productId);
            if (foundProduct == null) return false;
            _mapper.Map(productData, foundProduct);
            _appDbContext.Products.Update(foundProduct);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        //DeleteProduct method for Delete a product by Id

        public async Task<bool> DeleteProduct(Guid productId)
        {
            var foundProduct =await _appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (foundProduct == null) return false;
            _appDbContext.Products.Remove(foundProduct);
            await _appDbContext.SaveChangesAsync(); 
            return true;


        }

    } 
}

