using AutoMapper;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;
using Order_Management_System.Models;

namespace Order_Management_System.Services
{
    public class ProductService:IProductService
    {
        private static readonly List<Product> products = new List<Product>();

        private readonly IMapper mapper;

        public ProductService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        //GetAllProduct method for get all product

        public List<ProductReadDto> GetAllProduct()
        {
            return mapper.Map<List<ProductReadDto>>(products);

        }

        //GetAProduct method for get a product by Id

        public ProductReadDto? GetAProduct(Guid productId)
        {
            var foundProduct = products.FirstOrDefault(c => c.ProductId == productId);
            return foundProduct == null ? null : mapper.Map<ProductReadDto>(foundProduct);
        }

        //CreateProduct method for Create a product with data

        public ProductReadDto CreateProduct(ProductCreateDto productData)
        {
            var newProduct = mapper.Map<Product>(productData);
            newProduct.ProductId = Guid.NewGuid();
            newProduct.CreatedAt = DateTime.UtcNow;
            products.Add(newProduct);

            return mapper.Map<ProductReadDto>(newProduct);

        }

        //UpdateProduct method for Update a product by Id with data

        public bool UpdateProduct(Guid productId, ProductUpdateDto productData)
        {
            var foundProduct = products.FirstOrDefault(p => !string.IsNullOrEmpty(p.ProductName)  && p.ProductId == productId);
            if (foundProduct == null) return false;
            mapper.Map(productData, foundProduct);
            return true;
        }

        //DeleteProduct method for Delete a product by Id

        public bool DeleteProduct(Guid productId)
        {
            var foundProduct = products.FirstOrDefault(p => p.ProductId == productId);
            if (foundProduct == null) return false;
            products.Remove(foundProduct);
            return true;


        }

    } 
}

