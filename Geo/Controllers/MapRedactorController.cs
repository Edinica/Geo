using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Geo.Controllers
{
    public class MapRedactorController : Controller
    {
        // GET: MapRedactor
        //[Authorize(Roles = "User")]
        public ActionResult MapRedactor()
        {
            //if (User.IsInRole("User")) { ViewBag.Message = "user"; return View("Error"); }else 
            return View();
        }
        //[HttpPost]
        //public ActionResult MapRedactor(Models.Point point)
        //{
        //    //if (User.IsInRole("User")) { ViewBag.Message = "user"; return View("Error"); }else 
        //    return View(point);
        //}
    }

}