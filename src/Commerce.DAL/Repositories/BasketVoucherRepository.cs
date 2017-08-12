using Commerce.DAL.Data;
using Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.DAL.Repositories
{
    public class BasketVoucherRepository : RepositoryBase<BasketVoucher>
    {
        public BasketVoucherRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }

        public override void Delete(object id)
        {
            base.Delete(context.BasketVouchers.FirstOrDefault(x => x.Id == (int)id));
            base.Commit();
        }

        public override BasketVoucher GetById(object id)
        {
            return context.BasketVouchers.Single(s => s.Id == (int)id);
        }
    }
}
