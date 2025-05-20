using Order_Management_System.DTOs;

namespace Order_Management_System.Interfaces
{
    public interface IProductService
    {
       Task<List<ProductReadDto>> GetAllProduct();
        Task<ProductReadDto?> GetAProduct(Guid productId);
        Task<ProductReadDto> CreateProduct(ProductCreateDto productData);
        Task<bool> UpdateProduct(Guid productId, ProductUpdateDto productData);
        Task<bool> DeleteProduct(Guid productId);
    };
}
