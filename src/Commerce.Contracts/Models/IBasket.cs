using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface IBasket
    {
        string Id { get; set; }
        DateTime date { get; set; }

        ICollection<IBasketItem> IBasketItems { get; }
        ICollection<IBasketVoucher> IBasketVouchers { get; }

        string UserId { get; set; }

        void AddBasketItem(IBasketItem item);
        void AddBasketVoucher(IBasketVoucher voucher);
        decimal BasketTotal();
        decimal BasketItemCount();
    }
}
