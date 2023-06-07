using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class BasketItemDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price cannot be set to 0")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Quantity cannot be set to less than 1")]
        public int Quantity { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
