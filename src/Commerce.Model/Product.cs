using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Model
{
    public class Product : IProduct
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        public Product()
        {
            this.OrderItems = new HashSet<OrderItem>();
            this.BasketItems = new HashSet<BasketItem>();
        }

        public virtual ICollection<IOrderItem> IOrderItems
        {
            get
            {
                return OrderItems.Select(s => (IOrderItem)s).ToList();
            }
        }

        public virtual ICollection<IBasketItem> IBasketItems
        {
            get
            {
                return BasketItems.Select(s => (IBasketItem)s).ToList();
            }
        }
    }
}
