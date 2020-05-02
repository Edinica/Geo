using Geo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Geo.Controllers
{
    public class UserEditerController : Controller
    {
        // GET: UserEditer
        public ActionResult UserEditer()
        {
            ApplicationDbContext db = new ApplicationDbContext();


            return View(db.Users.ToList());
        }
    }
}