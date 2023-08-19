using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("OrderBills")]
    public class OrderBill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string NumberPayment { get; set; }
        public long MoneyPayment { get; set; }
        public DateTime DatePayment { get; set; }
        public bool Status { get; set; }





        [ForeignKey("OrderId")]
        public long OrderId { get; set; }
        public Order Order { get; set; }

    }
}
