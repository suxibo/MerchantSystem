using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MerchantSystem.Models.Merchant
{
    public enum MerchantStatus
    {
        [Description("未激活")]
        WaitForActive = 0,
        [Description("正常")]
        Normal = 1,
        [Description("已销户")]
        Closed = 2,
        [Description("已冻结")]
        Freezed = 3
    }
}