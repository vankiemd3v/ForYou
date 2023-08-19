using Data.Entities;

namespace ForYou.Dtos
{
    public class ContractDto
    {
        public long Id { get; set; }
        public string ContractNumber { get; set; }
        public string Customer { get; set; }
        public List<OrderDto>? Orders { get; set; }
    }
}
