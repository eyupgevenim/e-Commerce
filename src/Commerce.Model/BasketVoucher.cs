using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Model
{
    public class BasketVoucher : IBasketVoucher
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string VoucherCode { get; set; }

        [MaxLength(100)]
        public string VoucherType { get; set; }

        public decimal Value { get; set; }

        [MaxLength(150)]
        public string VoucherDescription { get; set; }

        public int AppliesToProductId { get; set; }

        public string BasketId { get; set; }
        public virtual Basket Basket { get; set; }

        public int VoucherId { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
