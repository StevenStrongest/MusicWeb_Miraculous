using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model;
using System.IO;

namespace MusicWeb.Areas.Admin.Controllers
{
    public class TheLoaiController : SessionController
    {
        // GET: Admin/TheLoai
        TheLoaiDAO dao = new TheLoaiDAO();
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
        public ActionResult AddNew(TheLoai obj, HttpPostedFileBase file)
        {

            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName += "_" + obj.IdTheLoai;
                    fileName += Path.GetExtension(file.FileName);

                    string folderPath = Server.MapPath("~") + @"\Assets\images\genrs";

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string path = Path.Combine(folderPath, fileName);

                    file.SaveAs(path);
                    obj.AnhTheLoai = fileName;
                    int id = dao.AddNew(obj);
                    if (id != -1)
                    {
                        return RedirectToAction("Index", "TheLoai");
                    }
                    else
                    {
                        ViewBag.Message("Them moi khong thanh cong");
                        return RedirectToAction("AddNew", "TheLoai");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bạn phải nhập vào trường này");
                }
                
            }
            catch
            {

            }
            return View();



        }
        public ActionResult Update(int id)
        {
            TheLoaiDAO dao = new TheLoaiDAO();
            var ud = dao.Detail(id);
            return View(ud);
        }
        [HttpPost]
        public ActionResult Update(TheLoai obj, HttpPostedFileBase file)
        {
            try
            {
                TheLoaiDAO dao = new TheLoaiDAO();
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName += "_" + obj.IdTheLoai;
                    fileName += Path.GetExtension(file.FileName);

                    string folderPath = Server.MapPath("~") + @"\Assets\images\genrs";

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string path = Path.Combine(folderPath, fileName);

                    file.SaveAs(path);
                    obj.AnhTheLoai = fileName;
                    if (dao.Update(obj))
                    {

                        return RedirectToAction("Index", "TheLoai");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Error");
                        return View(obj.IdTheLoai);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bạn phải nhập vào trường này");
                }
                
            }
            catch
            {

            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            dao.Delete(id);
            return RedirectToAction("Index", "TheLoai");
        }

    }
}