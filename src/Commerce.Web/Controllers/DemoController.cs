using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Commerce.Contracts.Repositories;
using Commerce.Model;

namespace Commerce.Web.Controllers
{
    public class DemoController : Controller
    {
        private readonly IRepositoryBase<Basket> _basket;

        public DemoController(IRepositoryBase<Basket> basket)
        {
            _basket = basket;
        }

        public IActionResult Index()
        {
            _basket.GetAll(x =>
            {
                x = x.Where(r => r.date == DateTime.Now);
                
                return x.OrderBy(o=>o.BasketItems);
            });
            return View();
        }

        public void CreateBasket(Basket basket)
        {
            _basket.Insert(basket);
            _basket.Commit();
        }

        public List<Basket> GetBaskets()
        {
           return _basket.GetAll().ToList();
        }
    }
}