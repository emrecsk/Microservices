using AutoMapper;
using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shared.DTOs;
using MongoDB.Driver;

namespace FreeCourse.Services.Catalog.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mapper = mapper;
            _courseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<Response<List<CourseDTO>>> GetCoursesAllAsync()
        {
            var courses = await _courseCollection.Find(course => true).ToListAsync(); //cannot get category info with this query because no sql database.
            if (courses.Any()){
                courses.ToList().ForEach(async x => x.Category = await _categoryCollection.Find(category => category.Id == x.CategoryId).FirstOrDefaultAsync());
            }
            else
            {
                return Response<List<CourseDTO>>.Fail("Course not found", 404);
            }
            return Response<List<CourseDTO>>.Success(_mapper.Map<List<CourseDTO>>(courses), 200);
        }
        public async Task<Response<CourseDTO>> GetCourseByIdAsync(string id)
        {
            var course = await _courseCollection.Find<Course>(course => course.Id == id).FirstOrDefaultAsync();
            if (course == null)
            {
                return Response<CourseDTO>.Fail("Course not found", 404);
            }

            course.Category = await _categoryCollection.Find<Category>(category => category.Id == course.CategoryId).FirstOrDefaultAsync();

            return Response<CourseDTO>.Success(_mapper.Map<CourseDTO>(course), 200);
        }
        public async Task<Response<List<CourseDTO>>> GetCourseByUserIdAsync(string userId)
        {
            var courses = await _courseCollection.Find<Course>(course => course.UserId == userId).ToListAsync();
            if (courses == null)
            {
                return Response<List<CourseDTO>>.Fail("Course not found", 404);
            }
            else
            {
                courses.ToList().ForEach(async x => x.Category = await _categoryCollection.Find<Category>(category => category.Id == x.CategoryId).FirstOrDefaultAsync());
            }
            return Response<List<CourseDTO>>.Success(_mapper.Map<List<CourseDTO>>(courses), 200);
        }
        public async Task<Response<CourseDTO>> CreateCourseAsync(CourseCreateDTO courseCreateDTO)
        {
            var newCourse = _mapper.Map<Course>(courseCreateDTO);
            newCourse.CreatedTime = DateTime.Now;
            await _courseCollection.InsertOneAsync(newCourse);
            return Response<CourseDTO>.Success(_mapper.Map<CourseDTO>(newCourse), 200);
        }
        public async Task<Response<NoContent>> UpdateCourseAsync(CourseUpdateDTO courseUpdateDTO)
        {
            var updateCourse = _mapper.Map<Course>(courseUpdateDTO);
            var result = await _courseCollection.FindOneAndReplaceAsync(course => course.Id == courseUpdateDTO.Id, updateCourse);
            if (result == null)
            {
                return Response<NoContent>.Fail("Course not found", 404);
            }
            return Response<NoContent>.Success(204);
        }
        public async Task<Response<NoContent>> DeleteCourseAsync(string id)
        {
            var result = await _courseCollection.DeleteOneAsync(course => course.Id == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Course not found", 404);
            }
        }
    }
}
