using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public interface IProductService
    {
        void AddProduct(NewProductDto dto);
        void DeleteProduct(Guid id);
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto GetProductById(Guid id);
        void UpdateProduct(UpdateProductDto dto);
    }
}