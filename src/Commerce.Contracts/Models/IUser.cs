using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Commerce.Contracts.Models
{
    public interface IUser
    {
        ICollection<IOrder> IOrders { get; }
        ICollection<IBasket> IBaskets { get; }
    }
}
