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

        public class Square
        {
            public string firstx { get; set; }
            public string firsty { get; set; }
            public string secondx { get; set; }
            public string secondy { get; set; }
            public string thirdx { get; set; }
            public string thirdy { get; set; }
            public string fourthx { get; set; }
            public string fourthy { get; set; }
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
            Point newp = new Point();
            if (res == null)
            {

                newp.X = Convert.ToInt32(po.firstx);
                newp.Y = Convert.ToInt32(po.firsty);
                db.Points.Add(newp);
                db.SaveChanges();
            }
            else { newp = res; }
            var res2 = Similar(Convert.ToInt32(po.secondx), Convert.ToInt32(po.secondy));
            if (res2 == null)
            {

                Point newp2 = new Point();
                newp2.X = Convert.ToInt32(po.secondx);
                newp2.Y = Convert.ToInt32(po.secondy);
                var last = db.Points.ToList().FirstOrDefault(x => x.X == newp.X && x.Y == newp.Y);
                last.points.Add(newp2);
                db.Points.Add(newp2);
                db.SaveChanges();
            }
            else 
            {
                var last = db.Points.ToList().FirstOrDefault(x => x.X == newp.X && x.Y == newp.Y);
                last.points.Add(res2);
                db.Points.Add(res2);
                db.SaveChanges();
            }

        }
        public void AddSquare([FromBody] Square po)
        {
            var pointslist = db.Points.ToList();
            var res = Similar(Convert.ToInt32(po.firstx), Convert.ToInt32(po.firsty));
            Point newp = new Point();
            newp.X = Convert.ToInt32(po.firstx);
            newp.Y = Convert.ToInt32(po.firsty);
            newp.PointId = pointslist.Count() + 1;
            //var obj = po;
            db.Points.Add(newp);
            db.SaveChanges();
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