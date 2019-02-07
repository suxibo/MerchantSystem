using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using MerchantSystem.Filters;
using MerchantSystem.Models.DbModels;
using MerchantSystem.Models.Merchant;
using MerchantSystem.Models.User;

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
            if (model.MerchantNo.HasValue())
            {
                ViewData.SetTitle("编辑商户");
            }
            else
            {
                ViewData.SetTitle("商户开户");
            }

            if (!ModelState.IsValid)
            {
                ViewData.SetErrorMessage(ModelState.GetFirstErrorMessage());
                return View(model);
            }

            var MinDeductionUnitPrice = (WebConfigurationManager.AppSettings["MinDeductionUnitPrice"] ?? String.Empty).ToDecimal();
            if (model.DeductionUnitPrice < MinDeductionUnitPrice)
            {
                ViewData.SetErrorMessage($"划扣费率不能小于{MinDeductionUnitPrice.ToString()}");
                return View(model);
            }

            using (var db = new MerchantDb())
            {
                String merchantNo = model.MerchantNo;
                if (merchantNo.HasValue())
                {
                    var find = db.Merchant.FirstOrDefault(x => String.Compare(x.MerchantNo, merchantNo, true) == 0);
                    model.Map(find);
                }
                else
                {
                    var newMerchant = new Merchant();
                    model.Map(newMerchant);
                    newMerchant.MerchantNo = $"{DateTime.Now.ToString("yyMMddHHmmssf")}";
                    newMerchant.CreateTime = DateTime.Now;
                    model.MerchantNo = newMerchant.MerchantNo;
                    db.Merchant.Add(newMerchant);
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewData.SetErrorMessage(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                    return View(model);
                }
            }

            ViewData.SetSuccessMessage("保存成功");
            return View(model);
        }

        [HttpGet]
        public ActionResult List()
        {
            String qsPage = Request.Unvalidated["page"];
            Int32 pageSize = Request.Unvalidated["size"].ToInt32(10);
            String keyword = (Request.Unvalidated["keyword"] ?? String.Empty).Trim();
            String merchantStatus = (Request.Unvalidated["merchant_status"] ?? String.Empty).Trim();

            var qsDic = new Dictionary<String, String>(3);
            if (keyword.HasValue())
            {
                qsDic["keyword"] = keyword;
                ViewData["Keyword"] = keyword;
            }
            if (merchantStatus.HasValue())
            {
                qsDic["merchant_status"] = merchantStatus;
                ViewData["MerchantStatus"] = merchantStatus;
            }

            if (qsDic.Count > 0)
            {
                ViewData.SetQS($"{(qsPage.HasValue() ? "&" : "?")}{String.Join("&", qsDic.Select(x => $"{x.Key}={x.Value}"))}");
            }

            using (var db = new MerchantDb())
            {
                var q = from t0 in db.Merchant
                        select new MerchantItem()
                        {
                            MerchantNo = t0.MerchantNo,
                            MerchantName = t0.MerchantName,
                            MerchantType = (MerchantType)t0.MerchantType,
                            MerchantStatus = (MerchantStatus)t0.MerchantStatus,
                            LegalPersonMobile = t0.LegalPersonMobile,
                            LegalPersonRealName = t0.LegalPersonRealName,
                            CreateTime = t0.CreateTime
                        };
                if (keyword.HasValue())
                {
                    q = from t0 in q
                        where String.Compare(t0.MerchantNo, keyword, true) == 0
                        || t0.MerchantName.Contains(keyword)
                        || t0.LegalPersonRealName.Contains(keyword)
                        || t0.LegalPersonMobile == keyword
                        select t0;
                }
                if (merchantStatus.HasValue())
                {
                    var ms = merchantStatus.ToInt32();
                    q = from t0 in q
                        where t0.MerchantStatus == (MerchantStatus)ms
                        select t0;
                }

                var ds = new PagedList<MerchantItem>(q.OrderByDescending(x => x.CreateTime), qsPage.ToInt32(1), pageSize);
                if (ds.Exception != null)
                {
                    ViewData.SetErrorMessage(ds.Exception.Message);
                    return View();
                }

                return View(ds);
            }
        }

        [HttpGet]
        public ActionResult Detail()
        {
            ViewData.SetTitle("商户详情");

            String merchantNo = Request.Unvalidated["merchantNo"];
            if (merchantNo.HasValue())
            {
                using (var db = new MerchantDb())
                {
                    var find = db.Merchant.FirstOrDefault(x => String.Compare(x.MerchantNo, merchantNo, true) == 0);
                    if (find == null)
                    {
                        ViewData.SetErrorMessage("商户不存在");
                        return View();
                    }

                    return View(find.Map<MerchantDetailModel>());
                }
            }

            return View();
        }

        [HttpPost]
        public JsonResult Active(String merchantNo)
        {
            if (merchantNo.IsNullOrWhiteSpace())
            {
                return Json(new { error = "merchantNo不可为空" });
            }

            using (var db = new MerchantDb())
            {
                var merchant = db.Merchant.FirstOrDefault(x => String.Compare(x.MerchantNo, merchantNo, true) == 0);
                if (merchant == null)
                {
                    return Json(new { error = "商户不存在" });
                }

                var userExisted = db.User.Count(x => String.Compare(x.MerchantNo, merchantNo, true) == 0) > 0;
                if (userExisted)
                {
                    return Json(new { error = "重复初始化" });
                }

                db.User.Add(new User()
                {
                    MerchantNo = merchant.MerchantNo,
                    RealName = merchant.LegalPersonRealName,
                    Mobile = merchant.LegalPersonMobile,
                    UserStatus = (Int32)UserStatus.Normal,
                    LoginPassword = Guid.NewGuid().ToString("n").Substring(0, 8),
                    CreateTime = DateTime.Now
                });

                merchant.MerchantStatus = (Int32)MerchantStatus.Normal;

                using (var tx = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return Json(new { error = (ex.InnerException != null ? ex.InnerException.Message : ex.Message) });
                    }

                    tx.Commit();
                }
            }

            return Json(new { success = true });
        }
    }
}