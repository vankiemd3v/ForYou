using AutoMapper;
using Data.Entities;
using ForYou.Dtos;
using static System.Net.Mime.MediaTypeNames;

namespace ForYou.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contract, ContractDto>();
            CreateMap<ContractDto, Contract>();


            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();


            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetail>();


            CreateMap<OrderBill, OrderBillDto>();
            CreateMap<OrderBillDto, OrderBill>();


            CreateMap<PaymentCycle, PaymentCycleDto>();
            CreateMap<PaymentCycleDto, PaymentCycle>();
        }
    }
}
