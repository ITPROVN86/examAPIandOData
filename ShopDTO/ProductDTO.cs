using System.ComponentModel.DataAnnotations;

namespace ShopDTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string ProductName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public int CategoryId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string? CategoryName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
