using AutoMapper;
using Data.EF;
using Data.Entities;
using ForYou.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ForYou.Services
{
    public class ContractService : IContractService
    {
        private readonly ForYouDbContext _context;
        private readonly IMapper _mapper;
        public ContractService(ForYouDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ContractDto>> GetContracts()
        {
            var contracts = await _context.Contracts.ToListAsync();
            if(contracts != null)
            {
                foreach(var contract in contracts)
                {
                    var orders = await _context.Orders.Where(x=>x.ContractId == contract.Id).ToListAsync();
                    if(orders != null)
                    {
                        contract.Orders = orders;
                        foreach(var order in orders)
                        {
                            var orderDetails = await _context.OrderDetails.Where(x => x.OrderId == order.Id).ToListAsync();
                            var orderBills = await _context.OrderBills.Where(x => x.OrderId == order.Id).ToListAsync();
                            if (orderDetails != null)
                            {
                                order.OrderDetails= orderDetails;
                            }
                            if(orderBills != null)
                            {
                                order.OrderBills = orderBills;
                            }
                            var paymentCycle = await _context.PaymentCycles.Where(x=>x.Id == order.PaymentCycleId).SingleOrDefaultAsync();
                            if(paymentCycle != null)
                            {
                                order.PaymentCycle = paymentCycle;
                            }
                        }
                    }
                }
            }
            var contractDtos = _mapper.Map<List<ContractDto>>(contracts);
            return contractDtos;
        }


        public async Task<ContractDto> GetById(long id)
        {
            var contract = await _context.Contracts.Where(x=>x.Id == id).SingleOrDefaultAsync();
            if (contract != null)
            {
                var orders = await _context.Orders.Where(x => x.ContractId == contract.Id).ToListAsync();
                if (orders != null)
                {
                    contract.Orders = orders;
                    foreach (var order in orders)
                    {
                        var orderDetails = await _context.OrderDetails.Where(x => x.OrderId == order.Id).ToListAsync();
                        var orderBills = await _context.OrderBills.Where(x => x.OrderId == order.Id).ToListAsync();
                        if (orderDetails != null)
                        {
                            order.OrderDetails = orderDetails;
                        }
                        if (orderBills != null)
                        {
                            order.OrderBills = orderBills;
                        }
                        var paymentCycle = await _context.PaymentCycles.Where(x => x.Id == order.PaymentCycleId).SingleOrDefaultAsync();
                        if (paymentCycle != null)
                        {
                            order.PaymentCycle = paymentCycle;
                        }
                    }
                }
            }
            var contractDto = _mapper.Map<ContractDto>(contract);
            return contractDto;
        }


        public async Task<long> Create(ContractDto dto)
        {
            var contract = _mapper.Map<Contract>(dto);
            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();
            return contract.Id;
        }
    }
}
