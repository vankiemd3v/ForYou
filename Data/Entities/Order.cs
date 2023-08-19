using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public long PriceService { get; set; }
        public long Tax { get; set; }
        public long TotalPayment { get; set; }
        public bool IsPostPaid { get; set; }



        public List<OrderDetail> OrderDetails { get; set; }
        public List<OrderBill> OrderBills { get; set; }


        [ForeignKey("ContractId")]
        public long ContractId { get; set; }
        public Contract Contract { get; set; }


        [ForeignKey("PaymentCycleId")]
        public long PaymentCycleId { get; set; }
        public PaymentCycle PaymentCycle { get; set; }

    }
}
