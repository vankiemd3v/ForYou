using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data.EF
{
    public class ForYouDbContext : DbContext
    {
        public ForYouDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<PaymentCycle> PaymentCycles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBill> OrderBills { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
