using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Task01.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            ViewBag.ErrorMessage = "Unknown Error";
            return View();
        }

        public ActionResult ServerError()
        {
            ViewBag.ErrorMessage = "Server side error";
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View();
        }

        public ActionResult NotFound()
        {
            ViewBag.ErrorMessage ="Page or item not found";
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult BadRequest()
        {
            ViewBag.ErrorMessage = "Bad request";
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return View();
        }

        public ActionResult UnauthorizedAccess()
        {
            ViewBag.ErrorMessage = "Unauthorized: Access denied";
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return View();
        }
    }
}