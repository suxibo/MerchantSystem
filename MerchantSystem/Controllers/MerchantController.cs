using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MerchantSystem.Filters;
using MerchantSystem.Models.DbModels;
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
                using (var db = new MerchantDb())
                {
                    var find = db.Merchant.FirstOrDefault(x => String.Compare(x.MerchantNo, merchantNo, true) == 0);
                    if (find == null)
                    {
                        ViewData.SetErrorMessage("商户不存在");
                        return View();
                    }

                    return View(find.Map<MerchantEditModel>());
                }
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
                return View(model);
            }

            using (var db = new MerchantDb())
            {
                String merchantNo = model.MerchantNo;
                if (merchantNo.HasValue())
                {
                    var find = db.Merchant.FirstOrDefault(x => String.Compare(x.MerchantNo, merchantNo, true) == 0);
                    model.Map(find);
                    ViewData.SetTitle("编辑商户");
                }
                else
                {
                    var newMerchant = new Merchant();
                    model.Map(newMerchant);
                    newMerchant.MerchantNo = $"{DateTime.Now.ToString("yyMMddHHmmssf")}";
                    model.MerchantNo = newMerchant.MerchantNo;
                    db.Merchant.Add(newMerchant);
                    ViewData.SetTitle("商户开户");
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewData.SetErrorMessage(ex.Message);
                    return View(model);
                }
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