using Commerce.DAL.Data;
using Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.DAL.Repositories
{
    public class VoucherTypeRepository : RepositoryBase<VoucherType>
    {
        public VoucherTypeRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }

        public override void Delete(object id)
        {
            base.Delete(context.VoucherTypes.FirstOrDefault(x => x.Id == (int)id));
            base.Commit();
        }

        public override VoucherType GetById(object id)
        {
            return context.VoucherTypes.Single(s => s.Id == (int)id);
        }
    }
}
