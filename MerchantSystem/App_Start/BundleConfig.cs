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
                .Include("~/content/lib/jbox/jBox.all.min.css")
                .Include("~/content/css/login.css")
            );

            bundles.Add(new StyleBundle("~/css/global")
                .Include("~/content/lib/jbox/jBox.all.min.css")
                .Include("~/content/css/global.css")
                .Include("~/content/css/leftsidebar.css")
                .Include("~/content/css/components.css")
            );

            bundles.Add(JQueryScriptBundle("~/js/login")
                .Include("~/content/lib/jbox/jBox.all.min.js")
                .Include("~/content/js/login.js")
            );

            bundles.Add(GlobalScriptBundle("~/js/merchant/edit")
                .Include("~/content/js/merchant.edit.js")
            );

            bundles.Add(GlobalScriptBundle("~/js/merchant/list")
               .Include("~/content/js/merchant.list.js")
           );

            BundleTable.EnableOptimizations = false;
        }

        private static ScriptBundle JQueryScriptBundle(String virtualPath)
        {
            var sb = new ScriptBundle(virtualPath);
            sb.Include("~/content/lib/jquery-v3.3.1.js");
            sb.Include("~/content/lib/jbox/jBox.all.min.js");
            return sb;
        }

        private static ScriptBundle GlobalScriptBundle(String virtualPath)
        {
            var sb = new ScriptBundle(virtualPath);
            sb.Include("~/content/lib/jquery-v3.3.1.js");
            sb.Include("~/content/lib/jbox/jBox.all.min.js");
            sb.Include("~/content/js/global.js");
            return sb;
        }
    }
}