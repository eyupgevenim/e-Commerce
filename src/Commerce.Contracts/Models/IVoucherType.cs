using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface IVoucherType
    {
        int Id { get; set; }
        string Description { get; set; }
        string Type { get; set; }
        string VoucherModule { get; set; }

        ICollection<IVoucher> IVouchers { get; }
    }
}
