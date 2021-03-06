﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MerchantSystem.Models.Auth;

namespace MerchantSystem
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString DropDownOptions<T>(this HtmlHelper helper, Object selectedValue = null)
        {
            var enumType = typeof(T);
            var items = from t0 in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static)
                        let x = t0.GetCustomAttribute<DescriptionAttribute>()
                        let v = GetValue(t0)
                        where x != null
                        select new SelectListItem()
                        {
                            Text = x.Description,
                            Value = v.ToString(),
                            Selected = selectedValue != null ? (v.ToString() == selectedValue.ToString()) : false
                        };

            if (items != null && items.Count() > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("<option value>========</option>");

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

        private static Object GetValue(FieldInfo field, Object instance = null)
        {
            try
            {
                var v = field.GetValue(instance);
                if (field.FieldType.IsEnum)
                {
                    return (Int32)v;
                }

                return v != null ? v.ToString() : String.Empty;
            }
            catch
            {
                return String.Empty;
            }
        }

        public static MvcHtmlString ResultMessage(this HtmlHelper helper)
        {
            var vd = helper.ViewData;
            String html = String.Empty;

            if (vd.GetErrorMessage().HasValue())
            {
                html = $"<div class=\"errmsg\">{vd.GetErrorMessage()}</div>";
            }
            else if (vd.GetSuccessMessage().HasValue())
            {
                html = $"<div class=\"succmsg\">{vd.GetSuccessMessage()}</div>";
            }

            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString SidebarStaticLink(this HtmlHelper helper, String text, String url)
        {
            String html = String.Empty;
            var vd = helper.ViewData;
            String title = (vd["Title"] ?? String.Empty).ToString();

            if (title == text)
            {
                html = $"<a class=\"selected\" href=\"{url}\">{text}</a>";
            }
            else
            {
                html = $"<a href=\"{url}\">{text}</a>";
            }

            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString SidebarDynamicLink(this HtmlHelper helper, String text)
        {
            String html = String.Empty;
            var vd = helper.ViewData;
            String title = (vd["Title"] ?? String.Empty).ToString();

            if (title == text)
            {
                html = $"<a class=\"selected\">{text}</a>";
            }

            return MvcHtmlString.Create(html);
        }

        public static UserSession GetUserSession(this HtmlHelper helper)
        {
            return helper.ViewContext.HttpContext.Session["UserSession"] as UserSession;
        }
    }
}