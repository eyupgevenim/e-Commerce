using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Model.Entities
{
    public class OrderItem : IOrderItem
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
