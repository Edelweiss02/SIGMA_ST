using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIGMA_ST.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SIGMA_ST.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
       [HttpGet]
       public IActionResult Index()
       {
            return View();
       }
       [HttpPost]
       public async Task<IActionResult> Index(Orders o)
        {
            DateTime thisDay = DateTime.Today;
            o.Date = thisDay;
            o.Cost = o.Gas.Price * o.Liters;
            db.DiscountCard.Add(o);
            await db.SaveChangesAsync();
            return RedirectToAction("History");
        }
        public IActionResult History()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateDiscountCard()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCard(DiscountCard ds)
        {
            ds.Bonuses = 0;
            db.DiscountCard.Add(ds);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
