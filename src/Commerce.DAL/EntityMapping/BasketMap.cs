using Commerce.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Commerce.DAL.EntityMapping
{
    public class BasketMap : EntityMappingConfigurationBase<Basket>
    {
        public override void Map(EntityTypeBuilder<Basket> b)
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.date).IsRequired();
            //...
            b.HasOne(o => o.User).WithMany(m => m.Baskets).HasForeignKey(f => f.UserId);
        }
    }
}
