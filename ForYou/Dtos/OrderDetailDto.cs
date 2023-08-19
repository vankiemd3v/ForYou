using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForYou.Dtos
{
    public class OrderDetailDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }
        public long IntoMoney { get; set; }
        public long Month { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long OrderId { get; set; }
        public OrderDto Order { get; set; }
    }
}
