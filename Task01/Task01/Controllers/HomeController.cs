using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task01.Security;
using Task01.Models;

namespace Task01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ProjectsContext();
       
           return View(db.Projects.AsEnumerable());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description Page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page.";
            return View();
        }

        public ActionResult RemoveAll()
        {
            int i = 0;
            using(var db = new ProjectsContext())
            {
                foreach(var item in db.Projects.ToList())
                {
                    db.Projects.Remove(item);
                    i++;
                }
                db.SaveChanges();
            }

            ViewBag.Message = i + " projects are removed.";
            return View();
        }
    }
}