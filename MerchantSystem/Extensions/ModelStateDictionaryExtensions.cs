using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MerchantSystem
{
    public static class ModelStateDictionaryExtensions
    {
        public static String GetFirstErrorMessage(this ModelStateDictionary msd)
        {
            if (msd != null && msd.Count > 0)
            {
                if (msd.Values != null)
                {
                    foreach (var v in msd.Values)
                    {
                        if (v.Errors != null && v.Errors.Count > 0)
                        {
                            return v.Errors[0].ErrorMessage;
                        }
                    }
                }
            }

            return String.Empty;
        }

        public static String GetErrorMessage(this ModelStateDictionary msd, String fieldName)
        {
            if (msd != null && msd.Count > 0)
            {
                if (msd.TryGetValue(fieldName, out ModelState value))
                {
                    if (value.Errors != null && value.Errors.Count > 0)
                    {
                        return value.Errors[0].ErrorMessage;
                    }
                }
            }

            return String.Empty;
        }
    }
}