using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchantSystem.Models.Merchant
{
    public class MerchantDetailModel
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public String MerchantNo { get; set; }
        /// <summary>
        /// 商户名称
        /// </summary>
        public String MerchantName { get; set; }
        /// <summary>
        /// 商户类型
        /// </summary>
        public Int32 MerchantType { get; set; }
        /// <summary>
        /// 账户状态
        /// </summary>
        public Int32 MerchantStatus { get; set; }
        /// <summary>
        /// 可用余额
        /// </summary>
        public Decimal BalanceAmount { get; set; }
        /// <summary>
        /// 冻结金额
        /// </summary>
        public Decimal FrozenAmount { get; set; }
        /// <summary>
        /// 划扣费率
        /// </summary>
        public Decimal DeductionUnitPrice { get; set; }
        /// <summary>
        /// 提现类型
        /// </summary>
        public String WithdrawType { get; set; }
        /// <summary>
        /// 法人姓名
        /// </summary>
        public String LegalPersonRealName { get; set; }
        /// <summary>
        /// 法人身份证号
        /// </summary>
        public String LegalPersonIdCardNo { get; set; }
        /// <summary>
        /// 法人手机号
        /// </summary>
        public String LegalPersonMobile { get; set; }

        public String MerchantPublicBankCode { get; set; }
        public String MerchantPublicBankName { get; set; }
        public String MerchantPublicBankAddress { get; set; }
        public String MerchantPublicBankMobile { get; set; }
        public String USCC { get; set; }
    }
}