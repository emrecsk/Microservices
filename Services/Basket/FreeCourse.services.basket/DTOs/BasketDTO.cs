namespace FreeCourse.services.basket.DTOs
{
    public class BasketDTO
    {
        public string UserId { get; set; } = null!;
        public string? DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDTO> Items { get; set; } = null!;

        public decimal TotalPrice
        {
            get => Items.Sum(i => i.Price * i.Quantity);
        }
    }
}
