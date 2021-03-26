using Model;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MusicWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Danh Sach Tat Ca Bai Hat
            BaiHatDAO bh = new BaiHatDAO();
            List<BaiHat> ls = bh.ListOf();
            ViewBag.NgheGanDay = ls;
            //Top 15 bai hat hay nhat
            var top15 = bh.Top15();
            ViewBag.Top15 = top15;
            //Nghệ Sĩ Nổi Bật
            NgheSiDAO ns = new NgheSiDAO();
            var NgheSiHot = ns.ListNgheSiHot();
            ViewBag.NgheSiNoiBat = NgheSiHot;
            //BaiHatMoiPhatHanh
            var mph = bh.MoiPhatHanh();
            ViewBag.MoiPhatHanh = mph;
            //Album Hot
            AlbumDAO al = new AlbumDAO();
            var album = al.AlbumHot();
            ViewBag.AlbumHot = album;
            //Thể Loại
            TheLoaiDAO tl = new TheLoaiDAO();
            var theloai = tl.TheLoaiListIEnnumable();
            ViewBag.TheLoai = theloai;
            return View();
        }

        public FileResult Dowload(int id)
        {
            BaiHatDAO bh = new BaiHatDAO();
            var data = bh.GetBaiHatById(id);
            string path = Server.MapPath("~/MusicDowload");
            string fileName = Path.GetFileName(data.LinkBaiHat);
            string fullPath = Path.Combine(path, fileName);

            return File(fullPath, "audio/mp3", data.LinkBaiHat);
        }
    }
}