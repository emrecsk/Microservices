using FreeCourse.IdentıtyServer.DTOs;
using FreeCourse.IdentıtyServer.Models.IdentityTables;
using FreeCourse.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.IdentıtyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
        {
            var user = new AppUser
            {
                UserName = signUpDTO.UserName,
                Email = signUpDTO.Email,
                City = signUpDTO.City
            };
            var result = await _userManager.CreateAsync(user, signUpDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(_obj => _obj.Description).ToList(), 400));
            }

            return NoContent();
        }
    }
}
