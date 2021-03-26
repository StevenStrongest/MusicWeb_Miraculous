using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWeb.Models
{
    public class BinhLuanModel
    {
        public int IdNguoiDung { set; get; }
        public int IdChung { set; get; }
        public string NoiDungBinhLuan { set; get; }
        public string TaiKhoan { set; get; }
        public string ThongTinh { set; get; }
    }
}