using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface IVoucher
    {
        int Id { get; set; }
        int AppliesToProductId { get; set; }
        string AssignedTo { get; set; }
        decimal MinSpend { get; set; }
        bool multipleUse { get; set; }
        decimal Value { get; set; }
        string VoucherCode { get; set; }
        string VoucherDescription { get; set; }

        int VoucherTypeId { get; set; }

        ICollection<IBasketVoucher> IBasketVouchers { get; }
    }
}
