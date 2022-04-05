namespace ProductManagementAPI.Models
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

    }
}
