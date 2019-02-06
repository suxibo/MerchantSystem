using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MerchantSystem.Models.Merchant
{
    [Serializable]
    public class MerchantEditModel
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public String MerchantNo { get; set; }
        /// <summary>
        /// 商户名称
        /// </summary>
        [Required(ErrorMessage = "商户名称必填")]
        public String MerchantName { get; set; }
        /// <summary>
        /// 商户类型
        /// </summary>
        [Required(ErrorMessage = "商户类型必填")]
        public Int32 MerchantType { get; set; }
        /// <summary>
        /// 账户状态
        /// </summary>
        [Required(ErrorMessage = "账户状态必填")]
        public Int32 MerchantStatus { get; set; }
        /// <summary>
        /// 可用余额
        /// </summary>
        [Required(ErrorMessage = "可用余额必填")]
        public Decimal BalanceAmount { get; set; }
        /// <summary>
        /// 冻结金额
        /// </summary>
        [Required(ErrorMessage = "冻结金额必填")]
        public Decimal FrozenAmount { get; set; }
        /// <summary>
        /// 划扣费率
        /// </summary>
        [Required(ErrorMessage = "划扣费率必填")]
        public Decimal DeductionUnitPrice { get; set; }
        /// <summary>
        /// 提现类型
        /// </summary>
        [Required(ErrorMessage = "提现类型必填")]
        [RegularExpression(@"^[a-zA-Z]\+\d$", ErrorMessage = "提现类型格式错误")]
        public String WithdrawType { get; set; }
        /// <summary>
        /// 法人姓名
        /// </summary>
        [Required(ErrorMessage = "法人姓名必填")]
        public String LegalPersonRealName { get; set; }
        /// <summary>
        /// 法人身份证号
        /// </summary>
        [Required(ErrorMessage = "法人身份证号必填")]
        public String LegalPersonIdCardNo { get; set; }
        /// <summary>
        /// 法人手机号
        /// </summary>
        [Required(ErrorMessage = "法人手机号必填")]
        public String LegalPersonMobile { get; set; }

        public String MerchantPublicBankCode { get; set; }
        public String MerchantPublicBankName { get; set; }
        public String MerchantPublicBankAddress { get; set; }
        public String MerchantPublicBankMobile { get; set; }
        public String USCC { get; set; }

    }
}