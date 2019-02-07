using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MerchantSystem.Models.User
{
    public enum UserStatus
    {
        [Description("正常")]
        Normal = 0,
        [Description("冻结")]
        Freezed = 1
    }
}