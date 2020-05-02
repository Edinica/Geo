using Geo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Geo.Controllers
{
	public class HomeController : Controller
	{
		
		public ActionResult Index()
		{
			IList<string> roles = new List<string> { "Роль не определена" };
			ApplicationUserManager userManager = HttpContext.GetOwinContext()
													.GetUserManager<ApplicationUserManager>();
			ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
			if (user != null)
				roles = userManager.GetRoles(user.Id);
			return View(roles);
		}
		[Authorize]
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[Authorize]
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			ApplicationDbContext db = new ApplicationDbContext();


			return View(db.Users.ToList());
		}

	}
}