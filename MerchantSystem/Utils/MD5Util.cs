using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MerchantSystem.Utils
{
    public static class MD5Util
    {
        public static String Compute(String input)
        {
            using (var md5 = MD5.Create())
            {
                var md5Data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (var b in md5Data)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}