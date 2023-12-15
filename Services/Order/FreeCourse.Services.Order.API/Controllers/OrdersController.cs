﻿using FreeCourse.Services.Order.APP.Commands;
using FreeCourse.Services.Order.APP.Queries;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrdersController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _mediator.Send(new GetOrderByUserIdQuery { UserId = _sharedIdentityService.GetUserId });
            return CreateActionResultInstance(response);
        }
        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderCommand createOrderCommand)
        {
            var response = await _mediator.Send(createOrderCommand);
            return CreateActionResultInstance(response);
        }
    }
}
