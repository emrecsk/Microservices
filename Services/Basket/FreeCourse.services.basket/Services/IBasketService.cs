using FreeCourse.services.basket.DTOs;
using FreeCourse.Shared.DTOs;

namespace FreeCourse.services.basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDTO>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDTO basketDTO);
        Task<Response<bool>> Delete(string userId);
    }
}
