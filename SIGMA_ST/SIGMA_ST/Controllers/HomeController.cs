using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIGMA_ST.Models;

namespace SIGMA_ST.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
       
      // public async Task<IActionResult> Index()
      // {
       //     return View(await db.Gas.ToListAsync());
      //  }
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Gas gas)
        {

            db.Gas.Add(gas);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult History()
        {
            return View();
        }
    }
}
