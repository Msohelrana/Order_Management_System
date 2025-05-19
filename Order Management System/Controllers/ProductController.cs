using Microsoft.AspNetCore.Mvc;
using Order_Management_System.DTOs;
using Order_Management_System.Interfaces;

namespace Order_Management_System.Controllers
{
    [ApiController]
    [Route("v1/api/products/")]
    public class ProductController : ControllerBase
    {

        private IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        //GET : read product

        [HttpGet]
        public IActionResult Getproducts([FromQuery] string searchValue = "")
        {

            var productReadDto = productService.GetAllProduct();
            return Ok(ApiResponse<List<ProductReadDto>>
           .SuccessResponse(productReadDto, 200, "Product Returned Successfully"));
        }

        //GET method for getting a single product by Id
        [HttpGet("{productId:guid}")]

        public IActionResult GetProductById(Guid productId)
        {
            var foundProduct = productService.GetAProduct(productId);
            if (foundProduct == null)
            {
                return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Product of this id does not exist!"));
            }
            return Ok(ApiResponse<ProductReadDto>.SuccessResponse(foundProduct, 200, "Category Returned Successfully!"));
        }

        //POST : create products
        [HttpPost]
        public IActionResult Createproducts([FromBody] ProductCreateDto productData)
        {
            var productReadDto = productService.CreateProduct(productData);

            return Created("v1/api/products/{newProduct.ProductId}", ApiResponse<ProductReadDto>
            .SuccessResponse(productReadDto, 201, "Product Created Successfully"));

        }

        //PUT: Update product

        [HttpPut("{productId:guid}")]

        public IActionResult Updateproducts(Guid productId, [FromBody] ProductUpdateDto productData)
        {
            var isUpdate = productService.UpdateProduct(productId, productData);
            if (isUpdate == false) return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Product of this id does not exist!"));

            return Ok(ApiResponse<object>
                .SuccessResponse(null, 200, "Product Updated Successfully"));

        }

        //DELETE:Delete a product
        [HttpDelete("{productId:guid}")]

        public IActionResult Deleteproducts(Guid productId)
        {
            var isDelete = productService.DeleteProduct(productId);
            if (isDelete == false) return NotFound(ApiResponse<object>
                .SuccessResponse(null, 404, "Product of this id does not exist!"));

            return Ok(ApiResponse<object>
                 .SuccessResponse(null, 200, "Product Deleted Successfully"));

        }




    }
}
