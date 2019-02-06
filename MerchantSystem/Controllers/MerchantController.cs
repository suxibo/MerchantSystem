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
            return View(new MerchantEditModel()
            {
                MerchantType = (Int32)MerchantType.Personal,
                MerchantStatus = (Int32)MerchantStatus.WaitForActive,
                WithdrawType = WithdrawType.T_0
            });
        }

        [HttpPost]
        public ActionResult Edit(MerchantEditModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData.SetErrorMessage(ModelState.GetFirstErrorMessage());
            }

            ViewData.SetSuccessMessage("保存成功");
            return View(model);
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }
    }
}