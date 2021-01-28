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
using System.Dynamic;

namespace SIGMA_ST.Controllers
{
    public class HomeController : Controller
    {
        private GasStationContext db;
        public HomeController(GasStationContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var gases = db.Gas.ToList();
            var orders = db.Orders.ToList();
            var discountcard = db.DiscountCards.ToList();
            var model = new ViewModel { Gases = gases, Orders = orders, DiscountCards = discountcard };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Ga g, Order o, DiscountCard dc, Invoice inv, ViewModel v)
        {
            DateTime thisday = DateTime.Today;
            int id = (from Gas in db.Gas where Gas.Price == v.Price select Gas.Idgas).Sum();
            inv.Idgas = id;
            o.Idgas = id;
            if (v.bon)
            {
                double fer = 0;
                dc.Bonuses = fer;
                db.DiscountCards.Attach(dc);
                db.Entry(dc).Property(x => x.Bonuses).IsModified = true;
                await db.SaveChangesAsync();
            }
            if (!(o.Idcard == null))
            {
                double fer = (from DiscountCards in db.DiscountCards where DiscountCards.Idcard == v.Idcard select DiscountCards.Bonuses).Sum();
                fer += o.Liters;
                dc.Bonuses = fer;
                db.DiscountCards.Attach(dc);
                db.Entry(dc).Property(x => x.Bonuses).IsModified = true;
            }
            o.Date = thisday;
            inv.Date = thisday;
            inv.EventType = "Покупка";
            inv.ChangeAmount = v.Cost;
            inv.Amount = v.Liters;
            inv.Idgas = id;
            db.Invoices.Add(inv);
            db.Orders.Add(o);

            double realNum = (from Gas in db.Gas where Gas.Idgas == id select Gas.Number).Sum();
            realNum -= o.Liters;
            g.Number = realNum;
            g.Idgas = id;
            db.Gas.Attach(g);
            db.Entry(g).Property(x => x.Number).IsModified = true;
            await db.SaveChangesAsync();
            return RedirectToAction("History");
        }
        public IActionResult History()
        {
            var invoices = db.Invoices.ToList();
            var gases = db.Gas.ToList();
            var model = new ViewModel2 { Invoices = invoices, Gases = gases };
            return View(model);
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
            db.DiscountCards.Add(ds);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateInvoice()
        {
            var invoices = db.Invoices.ToList();
            var gases = db.Gas.ToList();
            var model = new ViewModel3 { Invoices = invoices, Gases = gases };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateInvoice(Invoice inv, Ga g, ViewModel3 v)
        {
            DateTime thisday = DateTime.Today;
            int id = (from Gas in db.Gas where Gas.Price == v.Price select Gas.Idgas).Sum();
            g.Idgas = id;
            double realNum = (from Gas in db.Gas where Gas.Idgas == id select Gas.Number).Sum();
            realNum += v.Number;
            g.Number = realNum;
            db.Gas.Attach(g);
            db.Entry(g).Property(x => x.Number).IsModified = true;
            await db.SaveChangesAsync();
            g.Price = v.newPrice;
            g.Idgas = id;
            db.Gas.Attach(g);
            db.Entry(g).Property(x => x.Price).IsModified = true;
            await db.SaveChangesAsync();
            inv.Date = thisday;
            inv.EventType = "Поставка";
            inv.ChangeAmount = ((v.newPrice * v.Number) * -1);
            inv.ChangeAmount = Math.Round(inv.ChangeAmount, 2);
            inv.Amount = v.Number;
            inv.Idgas = id;
            db.Invoices.Add(inv);
            await db.SaveChangesAsync();
            return RedirectToAction("History");
        }
    }
}
