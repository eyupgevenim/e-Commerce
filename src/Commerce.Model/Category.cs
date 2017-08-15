using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Model
{
    public class Category : ICategory
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<IProduct> IProducts
        {
            get { return Products.Select(s => (IProduct)s).ToList(); }
        }

        public Category()
        {
            this.Products = new HashSet<Product>();
        }
    }
}
