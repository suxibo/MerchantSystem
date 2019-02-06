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
            if (merchantNo.HasValue())
            {
                ViewData.SetTitle("编辑商户");
            }
            else
            {
                ViewData.SetTitle("商户开户");
            }

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

            String merchantNo = model.MerchantNo;
            if (merchantNo.HasValue())
            {
                ViewData.SetTitle("编辑商户");
            }
            else
            {
                ViewData.SetTitle("商户开户");
            }

            ViewData.SetSuccessMessage("保存成功");
            return View(model);
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detail()
        {
            ViewData.SetTitle("商户详情");
            return View();
        }
    }
}