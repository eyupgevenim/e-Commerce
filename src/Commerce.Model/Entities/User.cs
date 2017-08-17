using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Commerce.Contracts.Models;

namespace Commerce.Model.Entities
{
    public class User : IdentityUser, IUser
    {
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<IOrder> IOrders
        {
            get { return Orders.Select(s => (IOrder)s).ToList(); }
        }

        public virtual ICollection<Basket> Baskets { get; set; }
        public virtual ICollection<IBasket> IBaskets
        {
            get { return Baskets.Select(s => (IBasket)s).ToList(); }
        }
        public User()
        {
            this.Orders = new HashSet<Order>();
            this.Baskets = new HashSet<Basket>();
        }
    }
}
