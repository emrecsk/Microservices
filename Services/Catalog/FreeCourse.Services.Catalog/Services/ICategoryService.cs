using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Shared.DTOs;

namespace FreeCourse.Services.Catalog.Services
{
    internal interface ICategoryService
    {
        Task<Response<List<CategoryDTO>>> GetAllAsync();
        Task<Response<CategoryDTO>> CategoryCreationAsync(CategoryDTO categoryDTO);
        Task<Response<CategoryDTO>> GetbyIdAsync(string id);
    }
}
