using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface IBasketVoucher
    {
        int Id { get; set; }
        int AppliesToProductId { get; set; }
        decimal Value { get; set; }
        string VoucherCode { get; set; }
        string VoucherDescription { get; set; }
        string VoucherType { get; set; }

        string BasketId { get; set; }

        int VoucherId { get; set; }
    }
}
