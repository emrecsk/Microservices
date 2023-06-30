using FreeCourse.Services.Catalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Services.Catalog.DTOs;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _courseService.GetCoursesAllAsync();
            return CreateActionResultInstance(response);
        }
        [HttpGet("{id}")] //api/course/id => it makes URL more readable
        public async Task<IActionResult> GetByID(string id)
        {
            var response = await _courseService.GetCourseByIdAsync(id);
            return CreateActionResultInstance(response);
        }
        [HttpGet]
        [Route("/api/[controller]/GetByUserId/{userId}")] //api/course/GetByUserId/4 => we already have a mothod like this which is GetByID so we need to change the route
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var response = await _courseService.GetCourseByUserIdAsync(userId);
            return CreateActionResultInstance(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDTO courseCreateDTO)
        {
            var response = await _courseService.CreateCourseAsync(courseCreateDTO);
            return CreateActionResultInstance(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDTO courseUpdateDTO)
        {
            var response = await _courseService.UpdateCourseAsync(courseUpdateDTO);
            return CreateActionResultInstance(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _courseService.DeleteCourseAsync(id);
            return CreateActionResultInstance(response);
        }
    }
}
