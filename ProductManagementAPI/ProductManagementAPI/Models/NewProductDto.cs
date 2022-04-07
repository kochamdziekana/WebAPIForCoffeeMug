﻿namespace ProductManagementAPI.Models
{
    public class NewProductDto // for adding new products
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
