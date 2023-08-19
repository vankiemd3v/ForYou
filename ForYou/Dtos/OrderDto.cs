using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForYou.Dtos
{
    public class OrderDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long PriceService { get; set; }
        public long Tax { get; set; }
        public long TotalPayment { get; set; }
        public bool IsPostPaid { get; set; }


        public List<OrderDetailDto> OrderDetails { get; set; }
        public List<OrderBillDto> OrderBills { get; set; }


        public long PaymentCycleId { get; set; }
        public PaymentCycleDto PaymentCycle { get; set; }


        public long ContractId { get; set; }
        public ContractDto Contract { get; set; }

    }
}
