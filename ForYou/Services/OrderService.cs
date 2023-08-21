using AutoMapper;
using Azure.Core;
using Data.EF;
using Data.Entities;
using ForYou.Dtos;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using static NuGet.Packaging.PackagingConstants;

namespace ForYou.Services
{
    public class OrderService : IOrderService
    {
        private readonly ForYouDbContext _context;
        private readonly IMapper _mapper;
        public OrderService(ForYouDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagingResponse<OrderBillDto>> GetOrdersPaymentDue(PagingRequest request)
        {
            // Lấy tất cả thông tin nhắc hạn thanh toán của phụ lục
            var orderBills = await _context.OrderBills.Where(x => x.DatePayment < DateTime.Now && x.Status == false).ToListAsync();
            if (orderBills != null && orderBills.Any())
            {
                foreach (var orderBill in orderBills)
                {
                    var order = await _context.Orders.Where(x => x.Id == orderBill.OrderId).SingleOrDefaultAsync();
                    if(order != null)
                    {
                        orderBill.Order = order;

                        // Phụ lục này thuộc hợp đồng nào?
                        var contract = await _context.Contracts.Where(x => x.Id == order.ContractId).SingleOrDefaultAsync();
                        if (contract != null)
                        {
                            order.Contract = contract;
                        }

                        // Lấy những dịch vụ của phụ lục
                        var orderDetails = await _context.OrderDetails.Where(x => x.OrderId == order.Id).ToListAsync();
                        if (orderDetails != null)
                        {
                            order.OrderDetails = orderDetails;
                        }
                    }
                }

                // Tìm kiếm
                if (!string.IsNullOrEmpty(request.Keyword))
                {
                    orderBills = orderBills.Where(x => x.Order.Name.Contains(request.Keyword) || x.Order.Contract.ContractNumber.Contains(request.Keyword)).ToList();
                }
                // Tổng item
                int count = orderBills.Count();
                // Phân trang
                var data = orderBills.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToList();
                var orderBillDtos = _mapper.Map<List<OrderBillDto>>(data);
                return new PagingResponse<OrderBillDto>()
                {
                    Items = orderBillDtos,
                    Count = count,
                    PageIndex = request.PageIndex,
                    PageSize = request.PageSize,
                };
            }
            return new PagingResponse<OrderBillDto>()
            {
                Items = null,
                Count = 0,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };
        }
       


    }
}
