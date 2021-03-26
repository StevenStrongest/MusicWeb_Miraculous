using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicWeb.Models;
using Model;
using System.IO;
using System.Web.Services.Description;

namespace MusicWeb.Areas.Admin.Controllers
{
    public class NgheSiController : SessionController
    {
        // GET: Admin/NgheSi
        public ActionResult Index()
        {
            NgheSiDAO dao = new NgheSiDAO();
            var result = dao.Listof();
            return View(result);
        }
        public ActionResult AddNew()
        {
            KhuVucDAO kvDAO = new KhuVucDAO();
            var kv = kvDAO.ListOf();
            ViewBag.kv = kv;
            return View();
            
        }
        [HttpPost]
        public ActionResult AddNew(NgheSi obj, HttpPostedFileBase file)
        {
           
            try
            {
                NgheSiDAO dao = new NgheSiDAO();
                
                if (file!=null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName += "_" + obj.IdNgheSi;
                    fileName += Path.GetExtension(file.FileName);

                    string folderPath = Server.MapPath("~") + @"\Areas\Admin\Asset\ImagesOutSource\imgsinger";
                    string folderPath2 = Server.MapPath("~") + @"\Assets\images\ImagesOutSource\ImagesSing";

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string path = Path.Combine(folderPath, fileName);
                    string path2 = Path.Combine(folderPath2, fileName);

                    file.SaveAs(path);
                    file.SaveAs(path2);
                    obj.AnhNgheSi = fileName;
                    int id = dao.AddNew(obj);
                    if (id != -1)
                    {
                        return RedirectToAction("Index", "NgheSi");
                    }
                    else
                    {
                        ViewBag.Message("Them moi khong thanh cong");
                        return RedirectToAction("AddNew", "NgheSi");
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
            KhuVucDAO kvDAO = new KhuVucDAO();
            var kv = kvDAO.ListOf();
            ViewBag.kv = kv;
            return View();

            

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            NgheSiDAO dao = new NgheSiDAO();
            dao.Delete(id);
           
            return RedirectToAction("Index", "NgheSi");
        }
        public ActionResult Update(int id)
        {
            KhuVucDAO kvDAO = new KhuVucDAO();
            var kv = kvDAO.ListOf();
            ViewBag.kv = kv;
            NgheSiDAO dao = new NgheSiDAO();
            var up = dao.Detail(id);
            return View(up);
        }
        [HttpPost]
        public ActionResult Update(NgheSi obj, HttpPostedFileBase file)
        {
            try
            {
                NgheSiDAO dao = new NgheSiDAO();
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName += "_" + obj.IdNgheSi;
                    fileName += Path.GetExtension(file.FileName);

                    string folderPath = Server.MapPath("~") + @"\Areas\Admin\Asset\ImagesOutSource\imgsinger";
                    string folderPath2 = Server.MapPath("~") + @"\Assets\images\ImagesOutSource\ImagesSing";

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string path = Path.Combine(folderPath, fileName);
                    string path2 = Path.Combine(folderPath, fileName);

                    file.SaveAs(path);
                    file.SaveAs(path2);
                    obj.AnhNgheSi = fileName;
                    if (dao.Update(obj))
                    {
                        
                        return RedirectToAction("Index", "NgheSi");
                        
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error");
                        return View(obj.IdNgheSi);
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
            KhuVucDAO kvDAO = new KhuVucDAO();
            var kv = kvDAO.ListOf();
            ViewBag.kv = kv;
            return View();
        }
    }
}