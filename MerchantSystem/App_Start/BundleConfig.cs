using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MerchantSystem
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/login")
                .Include("~/content/lib/weui/weui.min.css")
                .Include("~/content/lib/weui/jquery-weui.min.css")
                .Include("~/content/css/login.css")
            );

            bundles.Add(new StyleBundle("~/css/global")
                .Include("~/content/lib/weui/weui.min.css")
                .Include("~/content/lib/weui/jquery-weui.min.css")
                .Include("~/content/css/global.css")
                .Include("~/content/css/leftsidebar.css")
                .Include("~/content/css/components.css")
            );

            bundles.Add(new ScriptBundle("~/js/login")
                .Include("~/content/lib/jquery-v3.3.1.js")
                .Include("~/content/lib/weui/jquery-weui.min.js")
                .Include("~/content/js/login.js")
            );

            bundles.Add(new ScriptBundle("~/js/merchant")
                .Include("~/content/lib/jquery-v3.3.1.js")
                .Include("~/content/lib/weui/jquery-weui.min.js")
                .Include("~/content/js/global.js")
                .Include("~/content/js/merchant.edit.js")
            );

            BundleTable.EnableOptimizations = true;
        }
    }
}