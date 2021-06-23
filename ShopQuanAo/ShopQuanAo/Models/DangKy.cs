using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Models
{
    public class DangKy
    {
        public int maKH { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage="Bạn phải nhập tên đăng nhập")]
        public string taiKhoan { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string matKhau { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Nhập lại không đúng")]
        [Required(ErrorMessage = "Bạn phải nhập lại mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Bạn phải nhập tên")]
        public string tenHienThi { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bạn phải nhập Email")]
        public string email { get; set; }
    }
}