using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface ICategory
    {
        int Id { get; set; }
        string CategoryName { get; set; }
        string Description { get; set; }
        string Picture { get; set; }
        ICollection<IProduct> IProducts { get; }
    }
}
