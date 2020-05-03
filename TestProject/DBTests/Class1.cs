using Geo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.DBTests
{
	class Class1
	{
        private static ApplicationDbContext db = new ApplicationDbContext();
        // GET: Test
        public static void RefrashDb(bool delete = false)
        {
            // Удаляем бд, если она существуеты
            if (delete)
                db.Database.Delete();

            // Создаем бд, если она отсутствует
            db.Database.Create();
        }
        public static void SaveDb()
        {
            db.SaveChanges();
        }

        public static void LoadAll()
        {
            var Buildings = db.Buildings.ToList();
            var Floors = db.Floors.ToList();
            List<ApplicationUser> Users;
            if (db.Users.Count() > 0)
            {
                Users = db.Users.ToList();
            }
        }

        public static void ClearAll()
        {
            if (db.Buildings.Count() > 0)
                db.Buildings.RemoveRange(db.Buildings);
            if (db.Floors.Count() > 0)
                db.Floors.RemoveRange(db.Floors);
            var list = db.Users.ToList();
            foreach (var x in list)
            {
                db.Users.Remove(x);
            }
            db.SaveChanges();
        }

        public static void AddFloor(Floor floor)
        {
            if (floor == null) return;
            db.Floors.Add(floor);
            db.SaveChanges();
        }
        public static void AddFloor(List<Floor> floor)
        {
            foreach (var elem in floor)
            {
                db.Floors.Add(elem);
            }
            db.SaveChanges();
        }

        public static void Removefloor(Floor floor)
        {
            if (floor == null) return;
            //   if (db.Floors.Find(Floor) == null) return;
            db.Floors.Remove(floor);

            db.SaveChanges();
        }

        public static void RemoveFloor(List<Floor> Floors)
        {
            foreach (var Floor in Floors)
            {
                db.Floors.Remove(Floor);
            }
            db.SaveChanges();
        }

        public static void UpdateFloor(Floor Floor)
        {
            if (Floor == null) return;
            var floor = db.Floors.First(x => x.Id == Floor.Id);
            db.Floors.Remove(floor);
            db.Floors.Add(Floor);
            db.SaveChanges();
        }

        public static Floor FindFloor(Floor Floor)
        {
            if (Floor == null) return null;

            var Floors = db.Floors.Where(s =>
                                       s.BuildingId == Floor.BuildingId &&
                                       s.Description == Floor.Description &&
                                       s.Building == Floor.Building &&
                                       s.Id == Floor.Id &&
                                       s.Level == Floor.Level &&
                                       s.Points == Floor.Points
                                       );
            if (Floors.Count() > 0)
                return Floors.First();
            return null;
        }

        public static List<Floor> LoadAllFloors()
        {
            return db.Floors.ToList();
        }

        public static void AddBuilding(Building building)
        {
            db.Buildings.Add(building);
        }

        public static List<Building> LoadAllBuildings()
        {
            return db.Buildings.ToList();
        }



        public static bool isSavedUser()
        {
            if (db.Users.Count() > 0) return true;
            return false;
        }

        public static ApplicationUser LoadUserFromDb()
        {
            if (db.Users.Count() == 0) return null;
            return db.Users.ToList().First();
        }

        public static void SaveUser(ApplicationUser user)
        {
            if (user == null) return;
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static void RemoveUser(ApplicationUser user)
        {
            if (user == null) return;
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public static void LoadSample()
        {
            LoadSampleBuildings();
            LoadSamplFloors();

            SaveDb();

            LoadAll();
        }

        public static void LoadSamplFloors()
        {
            AddFloor(new Floor("Description1", 1, 1));
            AddFloor(new Floor("Description2", 2, 1));
            AddFloor(new Floor("Description3", 1, 2));
            AddFloor(new Floor("Description4", 2, 2));
        }

        public static void LoadSampleBuildings()
        {
            var list1 = new List<Floor>();
            list1.Add(new Floor("Description5", 1));
            list1.Add(new Floor("Description6", 2));
            AddBuilding(new Building("Building1", "Address1"));
            AddBuilding(new Building("Building2", "Address2"));
            AddBuilding(new Building("Building3", "Address3", list1));
        }

        public static ApplicationUser LoadSampleUserAsync(string login, string password, string email)
        {

            var user = new ApplicationUser
            {
                Email = email,
                EmailConfirmed = false,
                UserName = login,
                //Id = db.GetClientId()
            };
            db.Users.Add(user);


            //var userr = db.Users.First(x => x.UserName == login);
            //var list = userr.Roles.ToList();
            //list.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole());

            //.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole ("User"));


            // загружаю в базу данных

            SaveDb();

            return user;
        }
    }
}
