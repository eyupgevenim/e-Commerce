using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface IBasketItem
    {
        int Id { get; set; }
        int Quantity { get; set; }

        string BasketId { get; set; }

        int ProductId { get; set; }
    }
}
