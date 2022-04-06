using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Entities;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductManagementDbContext _dbContext;
        public ProductService(ProductManagementDbContext dbContext) // will get database context
        {
            _dbContext = dbContext;
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
