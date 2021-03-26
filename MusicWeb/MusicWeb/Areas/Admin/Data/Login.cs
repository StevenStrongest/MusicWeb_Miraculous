using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MusicWeb.Areas.Admin.Data
{
    public class Login
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Mời bạn đăng nhập tài khoản")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mời bạn đăng nhập mật khẩu")]
        public string Password { get; set; }
        public bool Rememberme { get; set; }

    }
}