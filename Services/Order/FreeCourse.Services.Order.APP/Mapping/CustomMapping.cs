using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.APP.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.OrderAggregate.Order, DTOs.OrderDTO>().ReverseMap();
            CreateMap<Domain.OrderAggregate.OrderItem, DTOs.OrderItemDTO>().ReverseMap();
            CreateMap<Domain.OrderAggregate.Address, DTOs.AddressDTO>().ReverseMap();
            CreateMap<Domain.OrderAggregate.Order, DTOs.CreatedOrderDTO>().ReverseMap();
        }
    }
}
