using Microsoft.AspNetCore.Mvc;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;

namespace Order_Management_System.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class ProductController : ControllerBase
    {

        private IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        //GET : read product

        [HttpGet]
        public async Task<IActionResult> Getproducts()
        {

            var productReadDto =await productService.GetAllProduct();
            return Ok(ApiResponse<List<ProductReadDto>>
           .SuccessResponse(productReadDto, 200, "Product Returned Successfully"));
        }

        //GET method for getting a single product by Id
        [HttpGet("{productId:guid}")]

        public async Task<IActionResult> GetProductById(Guid productId)
        {
            var foundProduct =await productService.GetAProduct(productId);
            if (foundProduct == null)
            {
                return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Product of this id does not exist!"));
            }
            return Ok(ApiResponse<ProductReadDto>.SuccessResponse(foundProduct, 200, "Category Returned Successfully!"));
        }

        //POST : create products
        [HttpPost]
        public async Task<IActionResult> Createproducts([FromBody] ProductCreateDto productData)
        {
            var productReadDto =await productService.CreateProduct(productData);

            return Created("v1/api/products/{newProduct.ProductId}", ApiResponse<ProductReadDto>
            .SuccessResponse(productReadDto, 201, "Product Created Successfully"));

        }

        //PUT: Update product

        [HttpPut("{productId:guid}")]

        public async Task<IActionResult> Updateproducts(Guid productId, [FromBody] ProductUpdateDto productData)
        {
            var isUpdate =await productService.UpdateProduct(productId, productData);
            if (isUpdate == false) return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Product of this id does not exist!"));

            return Ok(ApiResponse<object>
                .SuccessResponse(null, 200, "Product Updated Successfully"));

        }

        //DELETE:Delete a product
        [HttpDelete("{productId:guid}")]

        public async Task<IActionResult> Deleteproducts(Guid productId)
        {
            var isDelete =await productService.DeleteProduct(productId);
            if (isDelete == false) return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Product of this id does not exist!"));

            return Ok(ApiResponse<object>
                 .SuccessResponse(null, 200, "Product Deleted Successfully"));

        }




    }
}
