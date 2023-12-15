using FreeCourse.Services.Order.APP.DTOs;
using FreeCourse.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.APP.Commands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDTO>>
    {
        public string? BuyerId { get; set; }
        public decimal TotalPrice { get; set; }
        public AddressDTO? Address { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }
}
