using FreeCourse.IdentıtyServer.DTOs;
using FreeCourse.IdentıtyServer.Models.IdentityTables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.IdentıtyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTestController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UserTestController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUpTEST(SignUpDTO signUpDTO)
        {
            var user = new AppUser
            {
                UserName = signUpDTO.UserName,
                Email = signUpDTO.Email,
                City = signUpDTO.City
            };
            var result = await _userManager.CreateAsync(user, signUpDTO.Password);

            return NoContent();
        }
    }
}
