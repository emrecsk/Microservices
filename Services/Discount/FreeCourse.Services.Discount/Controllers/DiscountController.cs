using FreeCourse.Services.Discount.Services;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : CustomBaseController
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public DiscountController(IDiscountService discountService, ISharedIdentityService sharedIdentityService)
        {
            _discountService = discountService;
            _sharedIdentityService = sharedIdentityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResultInstance(await _discountService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResultInstance(await _discountService.GetById(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResultInstance(await _discountService.Delete(id));
        }
        [HttpPost]
        public async Task<IActionResult> Save(Models.Discount discount)
        {
            discount.UserId = _sharedIdentityService.GetUserId;            
            return CreateActionResultInstance(await _discountService.Save(discount));
        }
        [HttpGet]
        [Route("/api/[controller]/[action]/{code}")]        
        public async Task<IActionResult> GetByCodeAndUserId(string code)
        {
            return CreateActionResultInstance(await _discountService.GetByCodeAndUserId(code, _sharedIdentityService.GetUserId));
        }
        [HttpPut]        
        public async Task<IActionResult> Update(Models.Discount discount)
        {
            discount.UserId = _sharedIdentityService.GetUserId;
            return CreateActionResultInstance(await _discountService.Update(discount));
        }        
    }
}
