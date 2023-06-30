namespace FreeCourse.Services.Catalog.DTOs
{
    public class CourseDTO
    {
        public CourseDTO(string id, string name, decimal price, string picture, string description, string userId, DateTime createdTime, string categoryId, CategoryDTO category, FeatureDTO feature)
        {
            Id = id;
            Name = name;
            Price = price;
            Picture = picture;
            Description = description;
            UserId = userId;
            CreatedTime = createdTime;
            CategoryId = categoryId;
            Category = category;
            Feature = feature;
        }

        public string Id { get; set; }
        public string Name { get; set; }        
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public FeatureDTO Feature { get; set; }
    }
}
