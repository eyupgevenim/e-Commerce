using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface IOrder
    {
        int Id { get; set; }
        DateTime OrderDate { get; set; }

        string UserId { get; set; }

        ICollection<IOrderItem> IOrderItems { get; }
    }
}
