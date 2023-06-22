using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Shared.DTOs;

namespace FreeCourse.Services.Catalog.Services
{
    internal interface ICourseService
    {
        Task<Response<List<CourseDTO>>> GetCoursesAllAsync();
        Task<Response<CourseDTO>> GetCourseByIdAsync(string id);
        Task<Response<List<CourseDTO>>> GetCourseByUserIdAsync(string userId);
        Task<Response<CourseDTO>> CreateCourseAsync(CourseCreateDTO courseCreateDTO);
        Task<Response<NoContent>> UpdateCourseAsync(CourseUpdateDTO courseUpdateDTO);
        Task<Response<NoContent>> DeleteCourseAsync(string id);
    }
}
