using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Models
{
    public class Order : EntityBase
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem : EntityBase
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
