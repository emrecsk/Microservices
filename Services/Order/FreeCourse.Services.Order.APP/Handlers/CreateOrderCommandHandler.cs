using FreeCourse.Services.Order.APP.Commands;
using FreeCourse.Services.Order.APP.DTOs;
using FreeCourse.Services.Order.Domain.OrderAggregate;
using FreeCourse.Services.Order.Infrastructure;
using FreeCourse.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.APP.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDTO>>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedOrderDTO>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newaddress = new Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Line);
            
            Domain.OrderAggregate.Order neworder = new Domain.OrderAggregate.Order(request.BuyerId, newaddress);
            request.OrderItems.ForEach(x =>
            {
                neworder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureURL);
            });
            await _context.Orders.AddAsync(neworder);
            await _context.SaveChangesAsync();
            return Response<CreatedOrderDTO>.Success(new CreatedOrderDTO { OrderId = neworder.Id }, 200);
        }
    }
}
