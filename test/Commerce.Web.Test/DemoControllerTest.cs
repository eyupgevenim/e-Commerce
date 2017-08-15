using Commerce.Contracts.Repositories;
using Commerce.Model;
using Commerce.Web.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Commerce.Web.Test
{
    public class DemoControllerTest
    {
        [Fact]
        public void When_Get_List_Baskets()
        {
            var bList = new Basket []
            {
                new Basket {UserId ="user id 1",date =DateTime.Now },
                new Basket {UserId ="user id 2",date =DateTime.Now },
                new Basket {UserId ="user id 3",date =DateTime.Now },
                new Basket {UserId ="user id 4",date =DateTime.Now },
                new Basket {UserId ="user id 5",date =DateTime.Now }
            };

            var mockBasket = new Mock<IRepositoryBase<Basket>>();
            mockBasket.Setup(x => x.GetAll()).Returns(() => bList.AsQueryable());
            var demoController = new DemoController(mockBasket.Object);

            Assert.Equal(demoController.GetBaskets().Count(), 5);
        }
    }
}
