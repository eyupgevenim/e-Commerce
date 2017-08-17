using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Model.Entities
{
    public class VoucherType : IVoucherType
    {
        [Key]
        public int Id { get; set; }
        public string VoucherModule { get; set; }
        [MaxLength(30)]
        public string Type { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }
        public VoucherType()
        {
            this.Vouchers = new HashSet<Voucher>();
        }
        public virtual ICollection<IVoucher> IVouchers
        {
            get
            {
                return Vouchers.Select(s => (IVoucher)s).ToList();
            }
        }
    }
}
