using ProductManagementAPI.Entities;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public class ProductManagementDbSeeder
    {
        private readonly ProductManagementDbContext _dbContext;

        public ProductManagementDbSeeder(ProductManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            var newProducts = new List<Product>{
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "SampleProductOne",
                    Number = 10,
                    Quantity = 1,
                    Description = "Very Nice",
                    Price = 15
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "SampleProductTwo",
                    Number = 20,
                    Quantity = 2,
                    Description = "Also Nice",
                    Price = 10
                }
            };

            return newProducts;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Products.Any())
                {
                    var products = GetProducts();
                    _dbContext.AddRange(products);
                    _dbContext.SaveChanges();
                }

            }
        }
    }

}
