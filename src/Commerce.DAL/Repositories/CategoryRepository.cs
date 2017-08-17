using Commerce.DAL.Data;
using Commerce.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.DAL.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }

        public override void Delete(object id)
        {
            base.Delete(context.Categories.FirstOrDefault(x => x.Id == (int)id));
            base.Commit();
        }

        public override Category GetById(object id)
        {
            return context.Categories.Single(s => s.Id == (int)id);
        }
    }
}
