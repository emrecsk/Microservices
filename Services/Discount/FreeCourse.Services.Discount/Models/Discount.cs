namespace FreeCourse.Services.Discount.Models
{
    [Dapper.Contrib.Extensions.Table("Discount")]
    public class Discount
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int Rate { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
