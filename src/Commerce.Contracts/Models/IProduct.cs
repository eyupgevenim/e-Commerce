using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface IProduct
    {
        int Id { get; set; }
        decimal CostPrice { get; set; }
        string Description { get; set; }
        string ImageUrl { get; set; }
        decimal Price { get; set; }

        int CategoryId { get; set; }

        ICollection<IOrderItem> IOrderItems { get; }
        ICollection<IBasketItem> IBasketItems { get; }
    }
}
