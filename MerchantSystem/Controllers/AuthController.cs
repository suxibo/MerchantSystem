using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MerchantSystem.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}