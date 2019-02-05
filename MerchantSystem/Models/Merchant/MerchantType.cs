using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MerchantSystem.Models.Merchant
{
    /// <summary>
    /// 商户类型
    /// </summary>
    public enum MerchantType
    {
        [Description("个人")]
        Personal = 0,
        [Description("企业")]
        Company = 1
    }
}