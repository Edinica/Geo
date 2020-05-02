using Geo.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;
using System.Web.Http;

namespace Geo.Controllers
{
    public class PointsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Points
        public ActionResult Index()
        {
            return View();
        }
        public List<Point>  Getpoints()
        {
            return db.Points.ToList();
        }
        public void G()
        {
            var x = db.Points.ToList();

        }
        public class YourClass
        {
            public string firstx { get; set; }
            public string firsty { get; set; }
            public string secondx { get; set; }
            public string secondy { get; set; }
        }
        public Point Similar(int x, int y) 
        {
            var points = db.Points.ToList();
            foreach (var element in points)
            { 
                for (int i = -2; i < 2; i++)
                    for (int j = -2; j < 2; j++)
                    {
                        if (element.X+i == x && element.Y+j == y) return element;
                    } 
            }

            return null;
        }
        [System.Web.Http.HttpPost]
        public void Addpoint([FromBody] YourClass po)
        {
            var pointslist = db.Points.ToList();
            var res = Similar(Convert.ToInt32(po.firstx), Convert.ToInt32(po.firsty));
            //Point newp = new Point();
            //newp.X = Convert.ToInt32(po.firstx);
            //newp.Y = Convert.ToInt32(po.firsty);
            //newp.PointId = pointslist.Count() + 1;
            ////var obj = po;
            //db.Points.Add(newp);
            //db.SaveChanges();
        }

        //[HttpGet]
        //public void Addpoint(Newtonsoft.Json.Linq.JObject po)// это из контроллера, формирование тем, доступных пользователю и вывод их для компонента в формате Json
        //{

        //    var pointslist = this.Getpoints();
        //    var obj = po;
        //    pointslist.Add(new Point());




        //    //if (searchTerm != null)
        //    //{//CounrtyList = db.Topics.Where(x => x.TopicText.Contains(searchTerm)).ToList();
        //    //    pointslist = pointslist.Where(x => x.TopicText.Contains(searchTerm)).ToList();
        //    //}

        //    //new
        //    //{
        //    //    id = x.TopicId,
        //    //    text = x.TopicText
        //    //});
        //    //return Json(modifiedData, JsonRequestBehavior.AllowGet);
        //}
    }
    
}