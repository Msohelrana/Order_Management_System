using Order_Management_System.DTOs;

namespace Order_Management_System.Interfaces
{
    public interface IProductService
    {
        List<ProductReadDto> GetAllProduct();
        ProductReadDto? GetAProduct(Guid productId);
        ProductReadDto CreateProduct(ProductCreateDto productData);
        bool UpdateProduct(Guid productId, ProductUpdateDto productData);
        bool DeleteProduct(Guid productId);
    };
}
