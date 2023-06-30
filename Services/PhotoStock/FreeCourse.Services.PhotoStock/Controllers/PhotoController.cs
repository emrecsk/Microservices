using FreeCourse.Services.PhotoStock.DTOs;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> SavePhoto(IFormFile photo, CancellationToken cancellationToken) //cancellation token is used to cancel the request
        {
            if(photo == null || photo.Length <= 0)
            {
                return CreateActionResultInstance(Response<PhotoDTO>.Fail("Photo is not found", 400));
            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);

            using var stream = new FileStream(path, FileMode.Create);
            await photo.CopyToAsync(stream, cancellationToken); //cancellationToken is used to cancel the request if user closes the browser or something like that

            var returnPath = "photos/" + photo.FileName;

            PhotoDTO photoDTO = new() { Url = returnPath };

            return CreateActionResultInstance(Response<PhotoDTO>.Success(photoDTO, 200));
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult DeletePhoto(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            else
            {
                return CreateActionResultInstance(Response<NoContent>.Fail("Photo is not found", 404));
            }

            return CreateActionResultInstance(Response<NoContent>.Success(200));
        }
    }
}
