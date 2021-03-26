using Model;
using Model.DAO;
using MusicWeb.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        public ActionResult Index()
        {
            if(Session["taikhoan"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public JsonResult ListTaiKhoan()
        {
            NguoiDungDAO user = new NguoiDungDAO();
            var list = user.ListOf();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            NguoiDungDAO tk = new NguoiDungDAO();
            string user = f["user"].ToString();
            string pass = f["password"].ToString();
            if (tk.Login(user,pass))
            {
                var nguoidung = tk.GetNguoiDungById(user);
                Session["taikhoan"] = nguoidung;
                return RedirectToAction("Index", "NguoiDung");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Remove("taikhoan");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection f)
        {
            NguoiDungDAO nd = new NguoiDungDAO();
            NguoiDung user = new NguoiDung();
            user.TaiKhoan = f["user"];
            user.Email = f["email"];
            user.MatKhau = f["pass"];
            if(nd.Login(user.TaiKhoan, user.MatKhau))
            {

            }
            else
            {
                nd.AddNew(user);
                Session["taikhoan"] = user;
            } 
            return RedirectToAction("Index", "NguoiDung");
        }

        [HttpGet]
        public JsonResult ListVideoYeuThich()
        {
            var bh = new VideoYeuThichDAO();
            if (Session["taikhoan"] != null)
            {
                var id = ((NguoiDung)Session["taikhoan"]).IdNguoiDung;
                var list = bh.LitVideoYeuThich(id);
                return Json(list, JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.AllowGet);
        }

       public JsonResult AddVideoYeuThich(int id)
       {
            var video = new VideoYeuThich();
            video.IdVideo = id;
            video.IdNguoiDung = ((NguoiDung)Session["taikhoan"]).IdNguoiDung;
            VideoYeuThichDAO v = new VideoYeuThichDAO();
            var ktra = v.KiemTra(id, ((NguoiDung)Session["taikhoan"]).IdNguoiDung);
            if (ktra)
            {
                v.Add(video);
            }
            else
            {
                v.Delete(id, ((NguoiDung)Session["taikhoan"]).IdNguoiDung);
                return Json("delete", JsonRequestBehavior.AllowGet);
            }
           
            return Json("sucess", JsonRequestBehavior.AllowGet);
       }

        [HttpGet]
        public JsonResult AddNgheSiYeuThich(int id)
        {
            var nghesi = new NgheSiYeuThich();
            nghesi.IdNgheSi = id;
            nghesi.IdNguoiDung = ((NguoiDung)Session["taikhoan"]).IdNguoiDung;
            NgheSiYeuThichDAO v = new NgheSiYeuThichDAO();
            var ktra = v.KiemTra(id, ((NguoiDung)Session["taikhoan"]).IdNguoiDung);
            if (ktra)
            {
                v.Add(nghesi);
            }
            else
            {
                v.Delete(id, ((NguoiDung)Session["taikhoan"]).IdNguoiDung);
                return Json("error", JsonRequestBehavior.AllowGet);
            }

            return Json("sucess", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListNgheSiYeuThich()
        {
            var bh = new NgheSiYeuThichDAO();
            if (Session["taikhoan"] != null)
            {
                var id = ((NguoiDung)Session["taikhoan"]).IdNguoiDung;
                var list = bh.ListNgheSiYeuThich(id);
                return Json(list, JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult BinhLuan(string NoiDung)
        {
            var taikhoan = Session["taikhoan"] as NguoiDung;
            var video = Session["VideoById"] as Video;
            BinhLuanDAO binhluan = new BinhLuanDAO();
            BinhLuan bl = new BinhLuan();
            bl.IdNguoiDung = taikhoan.IdNguoiDung;
            bl.Idchung = video.IdVideo;
            bl.ThuocTinh = "Video";
            bl.NoiDungBinhLuan = NoiDung;
            binhluan.Add(bl);

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult ThongTinCaNhan()
        {
            if (Session["taikhoan"] == null)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.AnhDaiDien = (Session["taikhoan"] as NguoiDung).AnhDaiDien;
            }
            return View();
                         
        }

        [HttpPost]
        public ActionResult UpdateThongTinCaNhan(FormCollection f, HttpPostedFileBase file)
        {
            string fileName;
            if (file != null)
            {
                fileName = Path.GetFileNameWithoutExtension(file.FileName);
                fileName += Path.GetExtension(file.FileName);
                string folderPath = Server.MapPath("~") + @"Assets/avatar";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string path = Path.Combine(folderPath, fileName);

                file.SaveAs(path);
            }
            else
            {
                fileName = "";
            }
            
            
            NguoiDungDAO nd = new NguoiDungDAO();
            
            int id = Convert.ToInt32(f["id"]);
            var detail = nd.Detail(id);
            detail.DiaChi = f["diachi"];
            detail.TaiKhoan = f["taikhoan"];
            detail.TenNguoiDung = f["ten"];
            detail.Email = f["email"];
            detail.AnhDaiDien = fileName;
            Session["taikhoan"] = detail;
            nd.UpdateThongTinCaNhan(detail);
            return RedirectToAction("ThongTinCaNhan", "NguoiDung");
        }

        [HttpGet]
        public JsonResult ListBaiHatYeuThich()
        {
            var bh = new BaiHatYeuThichDAO();
            if(Session["taikhoan"] != null)
            {
                var id = ((NguoiDung)Session["taikhoan"]).IdNguoiDung;
                var list = bh.ListBaiHatYeuThich(id);
                return Json(list, JsonRequestBehavior.AllowGet);
            }

            return Json("error", JsonRequestBehavior.AllowGet);
           

        }
       
    }
}