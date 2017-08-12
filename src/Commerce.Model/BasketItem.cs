using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Model
{
    public class BasketItem : IBasketItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid BasketId { get; set; }
        public virtual Basket Basket { get; set; }
    }
}
