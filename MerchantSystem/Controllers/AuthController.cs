using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MerchantSystem.Models.Auth;
using MerchantSystem.Models.DbModels;
using MerchantSystem.Utils;

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
                ViewData.SetErrorMessage(ModelState.GetFirstErrorMessage());
                return View(form);
            }

            using (var db = new MerchantDb())
            {
                var user = db.SysUser.FirstOrDefault(x => String.Compare(x.UserName, form.UserName, true) == 0 || x.Mobile == form.UserName);
                if (user == null)
                {
                    ViewData.SetErrorMessage("用户不存在");
                    return View(form);
                }

                if (user.Password != MD5Util.Compute(form.Password))
                {
                    ViewData.SetErrorMessage("密码错误");
                    return View(form);
                }

                HttpContext.Session["UserSession"] = new UserSession()
                {
                    UserName = user.UserName,
                    RealName = user.RealName,
                    Mobile = user.Mobile
                };
            }

            return Redirect("/home/index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("UserSession");
            HttpContext.Session.Abandon();
            return Redirect("/auth/login");
        }
    }
}