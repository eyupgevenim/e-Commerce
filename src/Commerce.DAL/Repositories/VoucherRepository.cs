using Commerce.DAL.Data;
using Commerce.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.DAL.Repositories
{
    public class VoucherRepository : RepositoryBase<Voucher>
    {
        public VoucherRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }

        public override void Delete(object id)
        {
            base.Delete(context.Vouchers.FirstOrDefault(x => x.Id == (int)id));
            base.Commit();
        }

        public override Voucher GetById(object id)
        {
            return context.Vouchers.Single(s => s.Id == (int)id);
        }
    }
}
