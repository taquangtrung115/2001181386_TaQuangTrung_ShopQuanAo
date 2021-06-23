using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopQuanAo.Areas.Admin.Models
{
    public class TaiKhoanModels
    {
        public int maTK { get; set; }
        [Required(ErrorMessage="Bạn phải nhập tài khoản")]
        public string tenDN { set; get; }
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string matKhau { set; get; }
        public bool nhoMK { set; get; }
    }
}