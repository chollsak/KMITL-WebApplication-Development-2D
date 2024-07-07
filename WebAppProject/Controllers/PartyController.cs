using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppProject.Data;
using WebAppProject.Models;

namespace WebAppProject.Controllers
{
    public class PartyController : Controller
    {
        private readonly ApplicationDBContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PartyController(ApplicationDBContext db, IHttpContextAccessor httpContextAccessor) 
        {  
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost("/test/{Id}")]
        public IActionResult GetParty(Guid Id)
        {
            var user = _db.UsersData.FirstOrDefault(u => u.Id == Id);

            return Ok(user);
        }
        public IActionResult Index()
        {
            /*ViewBag.A = new { b="hello"};*/
            
            string Email = _httpContextAccessor.HttpContext.Session.GetString("Email");
            
            if (Email == null)
            {
                return NotFound();
            }
            var obj = _db.UsersData.FirstOrDefault(u => u.Email == Email);
            if (obj == null)
            {
                return NotFound();
            }

            IEnumerable<Party> allParty = _db.Partys;
            Console.WriteLine(allParty.Count());

            return View(allParty);
        }
        // GET Method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Party obj)
        {
            Console.WriteLine(obj.Time);
            string userEmail = _httpContextAccessor.HttpContext.Session.GetString("Email");
            DateTime dateTime = DateTime.Now;
            //var UserData = _db.UsersData.Find(userid);

            var UserData = (from user in _db.UsersData
                            where user.Email == userEmail
                            select user).FirstOrDefault();
            //var UserId = (from user in _db.UsersData
            //                where user.Email == userEmail
            //                 select user.id).FirstOrDefault();

            //var Parties = (from party in _db.Partys
            //                where party.Host == userEmail
            //                 select party).ToList();
            obj.Host = userEmail;
            obj.member = UserData.FirstName;
            if (obj.Time < dateTime)
            {
                return NotFound("That time has passedddd!!");
            }
            _db.Partys.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Party obj)
        {
            string email = _httpContextAccessor.HttpContext.Session.GetString("Email");

            Console.WriteLine(obj.Time);

            // Find the existing entity
            var existingParty = _db.Partys.Find(obj.Id);

            // Update the tracked entity
            _db.Entry(existingParty).CurrentValues.SetValues(obj);
            existingParty.Host = email;  // Update specific properties if needed

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _db.Partys.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Partys.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
		public IActionResult Join(Guid? Id)
		{
            string Email = _httpContextAccessor.HttpContext.Session.GetString("Email");
			var obj_party = _db.Partys.FirstOrDefault(u => u.Id == Id);
            var obj_user = _db.UsersData.FirstOrDefault(u => u.Email == Email);
            DateTime dateTime = DateTime.Now;
			if (Id == null)
            {
                return NotFound();
            }
            if (obj_party.Host == Email)
            {
                return NotFound("Sorry You are Host");
            }
            string[] allmember = obj_party.member.Split(',');
            foreach (string member in allmember)
            {
                if (member == obj_user.FirstName)
                {
                    Console.WriteLine(member);

                    return NotFound("You are already joined");
                }
                if (obj_party.Time <= dateTime)
                {
                    return NotFound("The party has been closed");
                }
                
            }
            if (allmember.Count() >= obj_party.Max)
            {

                return NotFound("Party is full");
            }
            obj_party.member = obj_party.member + "," + obj_user.FirstName;
            _db.Partys.Update(obj_party);
            _db.SaveChanges();
            return RedirectToAction("Index");
		}
	}
}
