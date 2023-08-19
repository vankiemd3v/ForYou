using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForYou.Dtos
{
    public class PaymentCycleDto
    {
        public long Id { get; set; }
        public long Month { get; set; }
        public string Description { get; set; }

    }
}
