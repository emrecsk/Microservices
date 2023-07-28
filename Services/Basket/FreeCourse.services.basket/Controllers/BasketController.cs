using FreeCourse.services.basket.DTOs;
using FreeCourse.services.basket.Services;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.services.basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketController(ISharedIdentityService sharedIdentityService, IBasketService basketService)
        {
            _sharedIdentityService = sharedIdentityService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var claims = User.Claims;
            return CreateActionResultInstance(await _basketService.GetBasket(_sharedIdentityService.GetUserId));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDTO basketDto)
        {
            var response = await _basketService.SaveOrUpdate(basketDto);
            return CreateActionResultInstance(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return CreateActionResultInstance(await _basketService.Delete(_sharedIdentityService.GetUserId));
        }
    }
}
