using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicWeb.Areas.Admin.Data
{
    public class BaiHatModelAdmin
    {
        public int ID { set; get; }
        public string TenBaiHat { set; get; }
        public string AnhBaiHat { set; get; }
        public string LoiBaihat { set; get; }
        public DateTime NgayPhatHanh { set; get; }
        public bool Top100 { set; get; }
        public int LuotNghe { set; get; }
        public int LuotTai { set; get; }
        public int LuotThich { set; get; }
        public string LinkBaiHat { set; get; }
        public int IdNgheSi { set; get; }
        public int IdTheLoai { set; get; }
        public int IdAlbum { set; get; }
        public string TenAlbum { get; set; }
        public string NgheSi { get; set; }
        public string TenTheLoai { get; set; }

        public BaiHatModelAdmin(int idbaihat, string tenbaihat, string anh,string lyric,DateTime ngayphathanh,bool top,int luotnghe,int luottai,int luotthich,
            string link,int idnghesi, int idtheloai,int idalbum, string tenAlbum,string nghesi,string tentheloai)
        {
            ID = idbaihat;
            TenBaiHat = tenbaihat;
            AnhBaiHat = anh;
            LoiBaihat = lyric;
            NgayPhatHanh = ngayphathanh;
            Top100 = top;
            LuotNghe = luotnghe;
            LuotTai = luottai;
            LuotThich = luotthich;
            LinkBaiHat = link;
            IdNgheSi = idnghesi;
            IdTheLoai = idtheloai;
            IdAlbum = idalbum;
            TenAlbum =tenAlbum;
            NgheSi = nghesi;
            TenTheLoai = tentheloai;
        }
        public string NgheDanh { get; set; }
        public string AnhNgheSi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QuocGia { get; set; }
        public string QueQuan { get; set; }
        public string CongTy { get; set; }
        public BaiHatModelAdmin(int idnghesi,string nghedanh,string anhnghesi,DateTime ngaysinh,string quocgia,string quequan,string congty)
        {
            IdNgheSi = idnghesi;
            NgheDanh = nghedanh;
            AnhNgheSi = anhnghesi;
            NgaySinh = ngaysinh;
            QuocGia = quocgia;
            QueQuan = quequan;
            CongTy = congty;
        }

    }
}