using Microsoft.AspNetCore.Mvc;
using SimpleLogin.Data;
namespace SimpleLogin.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext db;
        public ProductsController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("name")))
            {
                return RedirectToAction("Login", "Accounts");
            }
            ViewBag.Name = HttpContext.Session.GetString("name");
            return View(db.Products);
        }
    } 
}
