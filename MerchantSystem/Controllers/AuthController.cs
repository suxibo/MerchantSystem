using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MerchantSystem.Models.Auth;

namespace MerchantSystem.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = ModelState.GetFirstErrorMessage();
                return View();
            }

            return Redirect("/home/index");
        }
    }
}