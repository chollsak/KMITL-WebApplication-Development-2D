using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebAppProject.Data;
using WebAppProject.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAppProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ApplicationDBContext _db;

        public ProfileController(ApplicationDBContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            string Email = _httpContextAccessor.HttpContext.Session.GetString("Email");
            if (Email == null)
            {
                return NotFound();
            }
            var obj_user = _db.UsersData.FirstOrDefault(u => u.Email == Email);

            return View(obj_user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserData obj)
        {
            /*_db.UsersData.Update(obj);
            _db.SaveChanges();*/
            return View();
        }
    }
}
