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
    public class NhacCaNhanController : Controller
    {
        // GET: NhacCaNhan
        public ActionResult Index()
        {           
            return View();
        }

        public ActionResult Upload()
        {
            NhacCaNhanDAO nhac = new NhacCaNhanDAO();
            var listNhac = nhac.ListOf();
            if (Session["taikhoan"] != null)
            {
                return View(listNhac);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }           
        }

        [HttpGet]
        public JsonResult ListNhacCaNhan()
        {
            NhacCaNhanDAO nhac = new NhacCaNhanDAO();
            var listNhac = nhac.ListOf();
            return Json(listNhac, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeleteNhacCaNhan(int id)
        {
            NhacCaNhanDAO nhac = new NhacCaNhanDAO();
            nhac.Delete(id);
            return Json("suscess", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase anh, HttpPostedFileBase nhac, FormCollection f)
        {
            NhacCaNhan nc = new NhacCaNhan();
            nc.IdNguoiDung = (Session["taikhoan"] as NguoiDung).IdNguoiDung;
            nc.TenBaiHat = f["ten"];
            nc.NgheSiThucHien = f["nghesi"];

            //Ảnh
            string fileName = Path.GetFileNameWithoutExtension(anh.FileName);
            fileName += Path.GetExtension(anh.FileName);

            string folderPath = Server.MapPath("~") + @"/Assets/images/ImagesOutSource/ImagesSong";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string path = Path.Combine(folderPath, fileName);

            anh.SaveAs(path);
            nc.AnhBaiHat = fileName;
            //Nhạc
            string fileName2 = Path.GetFileNameWithoutExtension(nhac.FileName);
            fileName2 += Path.GetExtension(nhac.FileName);

            string folderPath2 = Server.MapPath("~") + @"/MusicDowload";

            if (!Directory.Exists(folderPath2))
            {
                Directory.CreateDirectory(folderPath2);
            }

            string path2 = Path.Combine(folderPath2, fileName2);

            nhac.SaveAs(path2);
            nc.LinkNhac = fileName2;

            NhacCaNhanDAO newSong = new NhacCaNhanDAO();
            newSong.Add(nc);
            var listNhacCaNhan = newSong.ListOf();

            return View(listNhacCaNhan);
        }
    }
}