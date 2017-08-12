using Commerce.DAL.Data;
using Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.DAL.Repositories
{
    public class OrdersRepository : RepositoryBase<Order>
    {
        public OrdersRepository(DataContext context) : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }

        public override void Delete(object id)
        {
            base.Delete(context.Orders.FirstOrDefault(x => x.Id == (int)id));
            base.Commit();
        }

        public override Order GetById(object id)
        {
            return context.Orders.Single(s => s.Id == (int)id);
        }
    }
}
