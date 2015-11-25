using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task01.DBContext;
using Task01.Models;

namespace Task01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           return View();
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
    }
}