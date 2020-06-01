using ShelterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShelterAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Adopt()
        {
            ViewBag.Message = "Your adopt page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Employee's login page.";
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Authorize(Employee userModel)
        {
            using(ShelterContext db = new ShelterContext())
            {
                var userDetails = db.Employees.Where(x => x.Login == userModel.Login && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Login", userModel);
                }
                else
                {
                    Session["login"] = userDetails.Login;
                    return RedirectToAction("Index", "Pets");
                }
            }
        }
    }
}