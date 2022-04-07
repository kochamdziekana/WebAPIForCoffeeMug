using AutoMapper;
using ProductManagementAPI.Entities;
using ProductManagementAPI.Exceptions;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProductService(ProductManagementDbContext dbContext, IMapper mapper) // will get database context
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _dbContext
                .Products
                .ToList();

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return productDtos;
        }

        public ProductDto GetProductById(Guid id)
        {
            var product = _dbContext
                .Products
                .FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                throw new ProductNotFoundException($"There is no product with id: {id}");
            }

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public Guid AddProduct(NewProductDto dto)
        {
            var newGuid = Guid.NewGuid();

            var product = _mapper.Map<Product>(dto);
            product.Id = newGuid;

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return newGuid;
        }

        public void UpdateProduct(UpdateProductDto dto)
        {
            var updatedProduct = _dbContext.Products.FirstOrDefault(p => p.Id == dto.Id);

            if (updatedProduct is null)
            {
                throw new ProductNotFoundException($"There is no product with id: {dto.Id}");
            }

            updatedProduct.Description = dto.Description;
            updatedProduct.Quantity = dto.Quantity;

            _dbContext.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            var productToBeDeleted = _dbContext
                .Products
                .FirstOrDefault(p => p.Id == id);

            if (productToBeDeleted is null)
            {
                throw new ProductNotFoundException($"There is no product with id: {id}");
            }

            _dbContext.Products.Remove(productToBeDeleted);
        }

    }
}
