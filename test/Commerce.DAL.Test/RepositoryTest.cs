using Commerce.Contracts.Repositories;
using Commerce.Model;
using Commerce.Web.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Commerce.DAL.Test
{
    public class RepositoryTest
    {
        [Fact]
        public void When_Get_Baskets()
        {
            var bList = new Basket[]
            {
                new Basket {UserId ="user id 1",date =DateTime.Now },
                new Basket {UserId ="user id 2",date =DateTime.Now },
                new Basket {UserId ="user id 3",date =DateTime.Now },
                new Basket {UserId ="user id 4",date =DateTime.Now },
                new Basket {UserId ="user id 5",date =DateTime.Now }
            };

            var mockBasket = new Mock<IRepositoryBase<Basket>>();
            mockBasket.Setup(x => x.GetAll()).Returns(() => bList.AsQueryable());

            Assert.Equal(mockBasket.Object.GetAll().Count(), 5);
        }
    }
}
