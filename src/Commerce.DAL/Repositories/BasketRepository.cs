using Commerce.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Model;

namespace Commerce.DAL.Repositories
{
    public class BasketRepository : RepositoryBase<Basket>
    {
        public BasketRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }

        public override void Delete(object id)
        {
            base.Delete(context.Baskets.FirstOrDefault(x => x.Id == (Guid)id));
            base.Commit();
        }

        public override Basket GetById(object id)
        {
            return context.Baskets.Single(s => s.Id == (Guid)id);
        }
    }
}
