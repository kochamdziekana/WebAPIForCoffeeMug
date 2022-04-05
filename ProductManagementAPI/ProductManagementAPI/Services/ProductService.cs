using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public class ProductService : IProductService
    {
        public ProductService() // will get database context
        {

        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            return new List<ProductDto>();
        }

        public ProductDto GetProductById(Guid id)
        {
            return new ProductDto();
        }

        public void AddProduct(NewProductDto dto)
        {

        }

        public void UpdateProduct(UpdateProductDto dto)
        {

        }

        public void DeleteProduct(Guid id)
        {

        }

    }
}
