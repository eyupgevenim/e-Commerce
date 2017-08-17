using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Model.Entities
{
    public class Voucher : IVoucher
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string VoucherCode { get; set; }

        [MaxLength(150)]
        public string VoucherDescription { get; set; }

        public int AppliesToProductId { get; set; }//this is so we can apply it to a specifc product

        public decimal Value { get; set; }

        public decimal MinSpend { get; set; }

        public bool multipleUse { get; set; }

        [MaxLength(255)]
        public string AssignedTo { get; set; }

        public int VoucherTypeId { get; set; }
        public virtual VoucherType VoucherType { get; set; }

        public virtual ICollection<BasketVoucher> BasketVouchers { get; set; }
        public Voucher()
        {
            this.BasketVouchers = new HashSet<BasketVoucher>();
        }
        public virtual ICollection<IBasketVoucher> IBasketVouchers
        {
            get
            {
                return BasketVouchers.Select(s => (IBasketVoucher)s).ToList();
            }
        }
    }
}
