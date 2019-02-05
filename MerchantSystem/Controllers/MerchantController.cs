using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MerchantSystem.Filters;
using MerchantSystem.Models.Merchant;

namespace MerchantSystem.Controllers
{
    public class MerchantController : Controller
    {
        [HttpGet]
        public ActionResult Edit()
        {
            String merchantNo = Request.Unvalidated["merchantNo"];
            return View(new MerchantEditModel());
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }
    }
}