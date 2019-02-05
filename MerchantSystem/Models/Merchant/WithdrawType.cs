using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MerchantSystem.Models.Merchant
{
    /// <summary>
    /// 商户状态
    /// </summary>
    public struct WithdrawType
    {
        [Description("T+0")]
        public const String T_0 = "T+0";
        [Description("D+0")]
        public const String D_0 = "D+0";
    }
}