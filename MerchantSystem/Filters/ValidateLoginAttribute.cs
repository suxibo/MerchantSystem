using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MerchantSystem.Filters
{
    public class ValidateLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!NeedAuthorize(filterContext))
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            var session = filterContext.HttpContext.Session["UserSession"];
            if (session == null)
            {
                filterContext.Result = new RedirectResult("/auth/login");
                return;
            }
        }

        private Boolean NeedAuthorize(ActionExecutingContext filterContext)
        {
            String requestUrl = filterContext.HttpContext.Request.Path;

            if (String.Compare(requestUrl, "/auth/login", true) == 0)
            {
                return false;
            }

            return true;
        }
    }
}