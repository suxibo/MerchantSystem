using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchantSystem.Models.Auth
{
    [Serializable]
    public class UserSession
    {
        public String UserName { get; set; }
        public String RealName { get; set; }
        public String Mobile { get; set; }
    }
}