using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Model
{
    public class Order : IOrder
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public string UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<IOrderItem> IOrderItems
        {
            get
            {
                return OrderItems.Select(s => (IOrderItem)s).ToList();
            }
        }
    }
}
