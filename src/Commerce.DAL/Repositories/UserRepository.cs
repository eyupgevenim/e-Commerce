using Commerce.DAL.Data;
using Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }

        public override void Delete(object id)
        {
            base.Delete(context.Users.FirstOrDefault(x => x.Id == id.ToString()));
            base.Commit();
        }

        public override User GetById(object id)
        {
            return context.Users.Single(s => s.Id == id.ToString());
        }
    }
}
