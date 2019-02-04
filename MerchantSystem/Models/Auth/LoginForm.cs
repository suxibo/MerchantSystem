using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MerchantSystem.Models.Auth
{
    [Serializable]
    public class LoginForm
    {
        [Required(ErrorMessage = "用户名不可为空")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "密码不可为空")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "密码应为6-20位")]
        public String Password { get; set; }
    }
}