using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace laptrinhweb.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        //[RegularExpression (@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Tối thiểu 8 ký tự, Phải có chữ cái, số và ký tự đặc biệt")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Hãy nhập lại mật khẩu!")]
        [Compare("Password", ErrorMessage = "Mật khẩu không đúng.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Định dạng Email không hợp lệ.")]

        public string Email {get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

    }
}