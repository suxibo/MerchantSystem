using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchantSystem.Models.Merchant
{
    [Serializable]
    public class MerchantItem
    {
        public String MerchantNo { get; set; }
        public String MerchantName { get; set; }
        public MerchantType MerchantType { get; set; }
        public MerchantStatus MerchantStatus { get; set; }
        public String LegalPersonRealName { get; set; }
        public String LegalPersonMobile { get; set; }
        public DateTime CreateTime { get; set; }
    }
}