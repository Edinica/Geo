using Geo.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Geo.Controllers
{
    public class UserEditerController : Controller
    {ApplicationDbContext db = new ApplicationDbContext();
        // GET: UserEditer
        public ActionResult UserEditer()
        {
            


            return View(db.Users.ToList());
        }
        [Authorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser User = db.Users.Find(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        // POST: Buildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser User = db.Users.Find(id);
            db.Users.Remove(User);
            db.SaveChanges();
            return RedirectToAction("UserEditer");
        }

        [Authorize]
        public ActionResult Admin(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser User = db.Users.Find(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        
        [HttpPost, ActionName("Admin")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AdminConfimed(string id)
        {
            ApplicationUser User = db.Users.Find(id);
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            userManager.AddToRoleAsync(id, "Admin");
            //db.Users.FirstOrDefault(x=>x.Id==id).Roles.Add(db.Roles.ToList().FirstOrDefault());
            //db.SaveChanges();
            return RedirectToAction("UserEditer");
        }
    }
}