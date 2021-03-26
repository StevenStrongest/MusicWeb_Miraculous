using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.DAO;

namespace MusicWeb.Areas.Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: Admin/NguoiDung
        NguoiDungDAO dao = new NguoiDungDAO();
        public ActionResult Index()
        {
            var result = dao.ListOf();
            return View(result);
        }
        public ActionResult AddNew()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddNew(NguoiDung obj, HttpPostedFileBase file)
        {

            int id = dao.AddNew(obj);
            if (file.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                fileName += "_" + obj.IdNguoiDung;
                fileName += Path.GetExtension(file.FileName);

                string folderPath = Server.MapPath("~") + @"\Assets\images\NguoiDung";


                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string path = Path.Combine(folderPath, fileName);


                file.SaveAs(path);

                obj.AnhDaiDien = fileName;
                if (id != -1)
                {
                    return RedirectToAction("Index", "NguoiDung");
                }
                else
                {
                    ViewBag.Message("Them moi khong thanh cong");
                    return RedirectToAction("AddNew", "NguoiDung");
                }
            }
            return View();


        }
        [HttpGet]
        public ActionResult Delete(int id)
        {

            dao.Delete(id);

            return RedirectToAction("Index", "NguoiDung");
        }
        public ActionResult Update(int id)
        {
            var up = dao.Detail(id);
            return View(up);
        }
        [HttpPost]
        public ActionResult Update(NguoiDung obj, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                fileName += "_" + obj.IdNguoiDung;
                fileName += Path.GetExtension(file.FileName);

                string folderPath = Server.MapPath("~") + @"\Areas\Admin\Asset\ImagesOutSource\nguoidung";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string path = Path.Combine(folderPath, fileName);


                file.SaveAs(path);

                obj.AnhDaiDien = fileName;
                if (dao.Update(obj))
                {
                    return RedirectToAction("Index", "NguoiDung");
                }
                else
                {
                    ModelState.AddModelError("", "Error");
                    return View(obj.IdNguoiDung);
                }
            }
            return View();
        }


    }
}