using Model;
using Model.DAO;
using MusicWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class BaiHatControllerController : Controller
    {
        // GET: BaiHatController
        [HttpGet]
        public JsonResult Index()
        {
            BaiHatDAO bh = new BaiHatDAO();
            List<BaiHatModel> ls = new List<BaiHatModel>();
            var list = bh.ListOf();
            for (int i = 0; i < list.Count; i++)
            {
                ls.Add(new BaiHatModel(list[i].LinkBaiHat, list[i].IdBaiHat, list[i].AnhBaiHat, list[i].TenBaiHat, list[i].NgheSi.TenNgheSi));
            }

            return Json(ls, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Search(string term)
        {
            TimKiemDAO tk = new TimKiemDAO();
            var kq = tk.AutoSearch(term);
            return Json(new
            {
                data = kq,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult UpdateView(int id)
        {
            BaiHatDAO bh = new BaiHatDAO();
            bh.UpdateViews(id);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult TatCaBaiHat()
        {

            var x = new BaiHatDAO().ListOf();
            return View(x);
        }


        public ActionResult ChiTietBaiHat(int id)
        {
            BaiHatDAO bh = new BaiHatDAO();
            var x = bh.GetBaiHatById2(id);
            var bhKhac = bh.ListOf();
            ViewBag.BaiHatKhac = bhKhac;
            return View(x);
        }

        [HttpGet]
        public JsonResult AddBaiHatYeuThich(int id)
        {
            var bh = new BaiHatYeuThich();
            bh.IdBaiHat = id;
            bh.TrangThaiThich = "thích";
            if (Session["taikhoan"] != null)
                bh.IdNguoiDung = (Session["taikhoan"] as NguoiDung).IdNguoiDung;
            BaiHatYeuThichDAO like = new BaiHatYeuThichDAO();
            if(like.KiemTra(id, (Session["taikhoan"] as NguoiDung).IdNguoiDung))
            {
                like.Add(bh);
            }
            else
            {
                like.Delete(id, (Session["taikhoan"] as NguoiDung).IdNguoiDung);
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult AddTrangThaiBaiHat(int id, string tt)
        {
            var bh = new BaiHatYeuThich();
            bh.IdBaiHat = id;
            bh.TrangThaiThich = tt;
            bh.IdNguoiDung = (Session["taikhoan"] as NguoiDung).IdNguoiDung;
            BaiHatYeuThichDAO x = new BaiHatYeuThichDAO();
            x.UpdateTrangThai(bh);
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult BaiHatTheoTheLoai(int id)
        {
            BaiHatDAO bh = new BaiHatDAO();
            TheLoaiDAO th = new TheLoaiDAO();
            var theloai = th.Detail(id);
            ViewBag.TheLoai = theloai.TenTheLoai;
            var x = bh.GetBaiHatByTheLoai(id);
            return View(x);
        }
    }
}