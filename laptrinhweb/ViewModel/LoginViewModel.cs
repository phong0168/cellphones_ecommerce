using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace laptrinhweb.ViewModel
{
    public class LoginViewModel
    {
        
        [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        public string Password { get; set; }
    }
}