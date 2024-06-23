using Microsoft.EntityFrameworkCore;
using MultiShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Persistance.Context
{
    public class OrderContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost,1434;initial catalog=MultiShopOrderDB;User=sa;Password=123456aA.");
        }

        public DbSet<Address> Addresses{ get; set; }
        public DbSet<OrderDetail> OrderDetails{ get; set; }
        public DbSet<Ordering> Orderings{ get; set; }
    }
}
