using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Model
{
    public class Basket : IBasket
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime date { get; set; }

        public virtual ICollection<BasketItem> BasketItems { get; set; }
        public virtual ICollection<BasketVoucher> BasketVouchers { get; set; }


        public Basket()
        {
            Id = Guid.NewGuid();
            this.BasketItems = new HashSet<BasketItem>();
            this.BasketVouchers = new HashSet<BasketVoucher>();
        }

        public virtual ICollection<IBasketItem> IBasketItems
        {
            get { return BasketItems.Select(s => (IBasketItem)s).ToList(); }
        }
        public virtual ICollection<IBasketVoucher> IBasketVouchers
        {
            get { return BasketVouchers.Select(i => (IBasketVoucher)i).ToList(); }
        }


        public virtual Guid UserId { get; set; }
        public virtual User User { get; set; }


        public void AddBasketItem(IBasketItem item)
        {
            BasketItems.Add((BasketItem)item);
        }

        public void AddBasketVoucher(IBasketVoucher voucher)
        {
            BasketVouchers.Add((BasketVoucher)voucher);
        }

        public decimal BasketItemCount()
        {
            return BasketItems.Count();
        }

        public decimal BasketTotal()
        {
            decimal? total = BasketItems.Select(i => (int)i.Quantity * i.Product.Price).Sum();
            return total ?? decimal.Zero;
        }
    }
}
