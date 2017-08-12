using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface IOrderItem
    {
        int Id { get; set; }

        int ProductId { get; set; }

        int OrderId { get; set; }

        string Description { get; set; }
        string ImageUrl { get; set; }
        int Quantity { get; set; }
        decimal Price { get; set; }
    }
}
