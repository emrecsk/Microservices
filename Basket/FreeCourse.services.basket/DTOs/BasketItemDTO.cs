using System.ComponentModel.DataAnnotations;

namespace FreeCourse.services.basket.DTOs
{
    public class BasketItemDTO
    {
        public int Quantity { get; set; }        
        public string CourseId { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
