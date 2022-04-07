using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(Guid id);
        Guid AddProduct(NewProductDto dto);
        void UpdateProduct(UpdateProductDto dto);
        void DeleteProduct(Guid id);
    }
}