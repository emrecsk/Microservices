using AutoMapper;

namespace FreeCourse.Services.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Models.Course, DTOs.CourseDTO>().ReverseMap();
            CreateMap<Models.Course, DTOs.CourseCreateDTO>().ReverseMap();
            CreateMap<Models.Course, DTOs.CourseUpdateDTO>().ReverseMap();

            CreateMap<Models.Category, DTOs.CategoryDTO>().ReverseMap();
            CreateMap<Models.Category, DTOs.CategoryCreateDTO>().ReverseMap();
            CreateMap<Models.Feature, DTOs.FeatureDTO>().ReverseMap();
        }
    }
}
