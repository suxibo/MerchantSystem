using System;
using System.Collections.Generic;
using System.Text;

namespace MerchantSystem
{
    /// <summary>
    /// String扩展类
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 将当前字符串安全地转换成Int32类型
        /// </summary>
        /// <param name="str"></param>
        public static Int32 ToInt32(this String str, Int32? defaultValue = null)
        {
            if (!String.IsNullOrWhiteSpace(str))
            {
                if (Int32.TryParse(str, out Int32 value))
                {
                    return value;
                }
            }

            return defaultValue.HasValue ? defaultValue.Value : 0;
        }

        /// <summary>
        /// 将当前字符串安全地转换成Int64类型
        /// </summary>
        /// <param name="str"></param>
        public static Int64 ToInt64(this String str, Int64? defaultValue = null)
        {
            if (!String.IsNullOrWhiteSpace(str))
            {
                if (Int64.TryParse(str, out Int64 value))
                {
                    return value;
                }
            }

            return defaultValue.HasValue ? defaultValue.Value : 0;
        }

        /// <summary>
        /// 将当前字符串安全地转换成Decimal类型
        /// </summary>
        /// <param name="str"></param>
        public static Decimal ToDecimal(this String str, Decimal? defaultValue = null)
        {
            if (!String.IsNullOrWhiteSpace(str))
            {
                if (Decimal.TryParse(str, out Decimal value))
                {
                    return value;
                }
            }

            return defaultValue.HasValue ? defaultValue.Value : 0.00m;
        }

        /// <summary>
        /// 将当前字符串安全地转换成DateTime类型
        /// </summary>
        /// <param name="str"></param>
        public static DateTime? ToDateTime(this String str)
        {
            if (str.HasValue() && DateTime.TryParse(str, out DateTime value))
            {
                return value;
            }

            return null;
        }

        /// <summary>
        /// 判断当前字符串是否为null，空格或空字符串。
        /// </summary>
        /// <param name="str"></param>
        public static Boolean IsNullOrWhiteSpace(this String str)
        {
            return String.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 判断当前字符串是否有值
        /// </summary>
        /// <param name="str"></param>
        public static Boolean HasValue(this String str)
        {
            return !str.IsNullOrWhiteSpace();
        }
    }
}
