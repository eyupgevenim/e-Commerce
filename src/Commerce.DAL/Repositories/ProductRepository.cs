using Commerce.DAL.Data;
using Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }

        public override void Delete(object id)
        {
            base.Delete(context.Products.FirstOrDefault(x => x.Id == (int)id));
            base.Commit();
        }

        public override Product GetById(object id)
        {
            return context.Products.Single(s => s.Id == (int)id);
        }
    }
}
