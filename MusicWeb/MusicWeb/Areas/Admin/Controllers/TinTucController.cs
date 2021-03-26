using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.IO;

namespace MusicWeb.Areas.Admin.Controllers
{
    public class TinTucController : SessionController
    {
        // GET: Admin/TinTuc
        TintucDAO dao = new TintucDAO();
        public ActionResult Index()
        {
            var result = dao.ListOf();
            return View(result);
        }
        public ActionResult AddNew()
        {
            TaiKhoanDAO TKdao = new TaiKhoanDAO();
            var ListTK = TKdao.Listof();
            ViewBag.TK = ListTK;
            return View();

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AddNew(Tintuc obj, HttpPostedFileBase fileTinTuc)
        {

            try
            {
                string fileName = Path.GetFileNameWithoutExtension(fileTinTuc.FileName);
                fileName += Path.GetExtension(fileTinTuc.FileName);

                string folderPath = Server.MapPath("~") + @"\Assets\images\ImagesOutSource\TinTuc";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string path = Path.Combine(folderPath, fileName);

                fileTinTuc.SaveAs(path);

                obj.AnhTieuDe = fileName;
                int id = dao.AddNew(obj);

                if (id != -1)
                {
                    ViewBag.Message("Thêm mới thành công");
                    return RedirectToAction("Index", "TinTuc");
                }
                else
                {
                    ViewBag.Message("Thêm mới không thành công");
                    return RedirectToAction("AddNew", "TinTuc");
                }
            }
            catch
            {

            }
            return RedirectToAction("Index", "TinTuc");
        }
        public ActionResult Update(int id)
        {
            TintucDAO dao = new TintucDAO();
            var up = dao.Detail(id);
            TaiKhoanDAO TKdao = new TaiKhoanDAO();
            var ListTK = TKdao.Listof();
            ViewBag.TK = ListTK;
            return View(up);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Update(Tintuc obj, HttpPostedFileBase fileTinTuc)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(fileTinTuc.FileName);
                fileName += Path.GetExtension(fileTinTuc.FileName);

                string folderPath = Server.MapPath("~") + @"\Assets\images\ImagesOutSource\TinTuc";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string path = Path.Combine(folderPath, fileName);

                fileTinTuc.SaveAs(path);

                TintucDAO tt = new TintucDAO();

                obj.AnhTieuDe = fileName;

                if (tt.Update(obj))
                    {

                        return RedirectToAction("Index", "TinTuc");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Error");
                        return View(obj.IdTinTuc);
                    }
                
            }
            catch
            {

            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteTinTuc(int id)
        {
            TintucDAO tt = new TintucDAO();
            tt.Delete(id);
            return RedirectToAction("Index", "TinTuc");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            dao.Delete(id);
            return RedirectToAction("Index", "TinTuc");
        }
    }
}