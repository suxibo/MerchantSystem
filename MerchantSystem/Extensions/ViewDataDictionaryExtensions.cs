using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MerchantSystem
{
    public static class ViewDataDictionaryExtensions
    {
        public static void SetErrorMessage(this ViewDataDictionary vdd, String message)
        {
            vdd["ErrorMessage"] = message;
        }

        public static void SetSuccessMessage(this ViewDataDictionary vdd, String message)
        {
            vdd["SuccessMessage"] = message;
        }

        public static void SetTitle(this ViewDataDictionary vdd, String title)
        {
            vdd["Title"] = title;
        }

        public static void SetQS(this ViewDataDictionary vdd, String queryString)
        {
            vdd["QueryString"] = queryString;
        }

        public static String GetQS(this ViewDataDictionary vdd)
        {
            return (vdd["QueryString"] ?? String.Empty).ToString();
        }

        public static String GetErrorMessage(this ViewDataDictionary vdd)
        {
            return (vdd["ErrorMessage"] ?? String.Empty).ToString();
        }

        public static String GetSuccessMessage(this ViewDataDictionary vdd)
        {
            return (vdd["SuccessMessage"] ?? String.Empty).ToString();
        }

        public static String GetTitle(this ViewDataDictionary vdd)
        {
            return (vdd["Title"] ?? String.Empty).ToString();
        }
    }
}