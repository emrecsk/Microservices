using FreeCourse.Services.Order.APP.DTOs;
using FreeCourse.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.APP.Queries
{
    public class GetOrderByUserIdQuery : IRequest<Response<List<OrderDTO>>> // IRequest<Response<List<OrderDTO>>> means that this query will return a Response<List<OrderDTO>> object
    {
        public string? UserId{ get; set; }
    }
}
