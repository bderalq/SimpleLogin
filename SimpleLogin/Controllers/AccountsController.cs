using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleLogin.Data;
using SimpleLogin.Models;

namespace SimpleLogin.Controllers
{
    public class AccountsController : Controller
    {
        private AppDbContext db;
        public AccountsController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()

        {
            ViewBag.role = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");

            }
            ViewBag.role = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var data = db.Users.Where(x => x.Name == user.Name && x.Password == user.Password);

            if (data.Any())
            {
                return RedirectToAction("AllUsers");
            }
            else
            {
                return View();
            }
        }
        public IActionResult AllUsers()
        {
            return View(db.Users);
        }
    }
}
