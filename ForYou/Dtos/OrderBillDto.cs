using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForYou.Dtos
{
    public class OrderBillDto
    {
        public long Id { get; set; }
        public string NumberPayment { get; set; }
        public long MoneyPayment { get; set; }
        public DateTime DatePayment { get; set; }
        public bool Status { get; set; }





        public long OrderId { get; set; }
        public OrderDto Order { get; set; }

    }
}
