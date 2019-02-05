using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MerchantSystem
{
    public static class HtmlHelperExtensions
    {
        private static readonly ConcurrentDictionary<Type, IEnumerable<SelectListItem>> _cache = new ConcurrentDictionary<Type, IEnumerable<SelectListItem>>();

        public static MvcHtmlString DropDownOptions<T>(this HtmlHelper helper, Object selectedValue = null)
        {
            var enumType = typeof(T);

            if (!_cache.TryGetValue(enumType, out IEnumerable<SelectListItem> items))
            {
                try
                {
                    items = from t0 in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)
                            let x = t0.GetCustomAttribute<DescriptionAttribute>()
                            let v = t0.GetValue(null) ?? String.Empty
                            where x != null
                            select new SelectListItem()
                            {
                                Text = x.Description,
                                Value = v.ToString(),
                                Selected = (v == selectedValue)
                            };
                }
                catch { }
            }

            if (items != null && items.Count() > 0)
            {
                _cache[enumType] = items;

                StringBuilder sb = new StringBuilder();
                sb.Append("<option>========</option>");

                foreach (var item in items)
                {
                    sb.Append($"<option value=\"{item.Value}\"");
                    if (item.Selected)
                    {
                        sb.Append($" selected=\"selected\"");
                    }
                    sb.Append($">{item.Text}</option>");
                }
                return MvcHtmlString.Create(sb.ToString());
            }

            return MvcHtmlString.Empty;
        }
    }
}