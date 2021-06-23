using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopQuanAo.Models
{
    public class DangNhap
    {
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage="Bạn phải nhập tài khoản")]
        public string taiKhoan { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string matKhau { get; set; }
    }
}