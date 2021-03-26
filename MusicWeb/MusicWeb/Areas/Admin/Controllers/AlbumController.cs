using Model;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Areas.Admin.Controllers
{
    public class AlbumController : SessionController
    {
        // GET: Admin/Album
        public ActionResult Index()
        {
            AlbumDAO dao = new AlbumDAO();
            
            var result = dao.Listof();
            return View(result);
        }

        public ActionResult Addalbum()
        {
            NgheSiDAO nsDAO = new NgheSiDAO();
            var ns = nsDAO.Listof();
            KhuVucDAO kvDAO = new KhuVucDAO();
            var kv = kvDAO.ListOf();
            ViewBag.ns = ns;
            ViewBag.kv = kv;
            return View();
        }

        [HttpPost]
        public ActionResult Addalbum(Album obj, HttpPostedFileBase file)
        {
            AlbumDAO dao = new AlbumDAO();
            
            if (file!= null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                fileName += "_" + obj.IdAlbum;
                fileName += Path.GetExtension(file.FileName);

                string folderPath = Server.MapPath("~") + @"\Assets\images\ImagesOutSource\ImagesSong";
                string folderPath2 = Server.MapPath("~") + @"\Assets\images\ImagesOutSource\Album";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string path = Path.Combine(folderPath, fileName);
                string path2 = Path.Combine(folderPath2, fileName);

                file.SaveAs(path);
                file.SaveAs(path2);
                obj.AnhAlbum = fileName;
                int id = dao.Addalbum(obj);
                if (id != -1)
                {
                    return RedirectToAction("Index", "Album");
                }
                else
                {
                    ViewBag.Message("Them moi khong thanh cong");
                    return RedirectToAction("Addalbum", "Album");
                }
            }
            else
            {
                ModelState.AddModelError("", "Bạn phải nhập vào trường này");
            }
            NgheSiDAO nsDAO = new NgheSiDAO();
            var ns = nsDAO.Listof();
            KhuVucDAO kvDAO = new KhuVucDAO();
            var kv = kvDAO.ListOf();
            ViewBag.ns = ns;
            ViewBag.kv = kv;
            return View();
            

        }
        [HttpGet]
        public ActionResult DeleteAlbum(int id)
        {
            AlbumDAO dao = new AlbumDAO();
            dao.DeleteAlbum(id);

            return RedirectToAction("Index", "Album");
        }
        public ActionResult Update(int id)
        {
            AlbumDAO dao = new AlbumDAO();
            NgheSiDAO nsDAO = new NgheSiDAO();
            var ns = nsDAO.Listof();
            KhuVucDAO kvDAO = new KhuVucDAO();
            var kv = kvDAO.ListOf();
            ViewBag.ns = ns;
            ViewBag.kv = kv;
            var up = dao.Detail(id);
            return View(up);
        }
        [HttpPost]
        public ActionResult Update(Album obj, HttpPostedFileBase file)
        {
            AlbumDAO dao = new AlbumDAO();
             
            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                fileName += "_" + obj.IdAlbum;
                fileName += Path.GetExtension(file.FileName);

                string folderPath = Server.MapPath("~") + @"\Assets\images\ImagesOutSource\ImagesSong";
                string folderPath2 = Server.MapPath("~") + @"\Assets\images\ImagesOutSource\Album";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string path = Path.Combine(folderPath, fileName);
                string path2 = Path.Combine(folderPath2, fileName);

                file.SaveAs(path);
                file.SaveAs(path2);
                obj.AnhAlbum = fileName;
                if (dao.UpdateAlbum(obj))
                {
                    return RedirectToAction("Index", "Album");
                }
                else
                {
                    ModelState.AddModelError("", "Error");
                    return View(obj.IdAlbum);
                }
            }
            else
            {
                ModelState.AddModelError("", "Bạn phải nhập vào trường này");
            }
            NgheSiDAO nsDAO = new NgheSiDAO();
            var ns = nsDAO.Listof();
            KhuVucDAO kvDAO = new KhuVucDAO();
            var kv = kvDAO.ListOf();
            ViewBag.ns = ns;
            ViewBag.kv = kv;
            return View();
            //try
            //{
            //    AlbumDAO dao = new AlbumDAO();
            //    if (dao.UpdateAlbum(ab))
            //    {
            //        return RedirectToAction("Index", "Album");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Error");
            //        return View(ab.IdAlbum);
            //    }
        
            

        }
        public ActionResult Upload(int id)
        {
            AlbumDAO dao = new AlbumDAO();
            var ab = dao.Detail(id);
            return View(ab);
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, Album obj)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName += "_" + obj.IdAlbum;
                    fileName += Path.GetExtension(file.FileName);

                    string folderPath = Server.MapPath("~") + @"\Assets\images\ImagesOutSource\ImagesSong";

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string path = Path.Combine(folderPath, fileName);

                    file.SaveAs(path);

                    var dao = new AlbumDAO();
                    dao.Upload(obj.IdAlbum, fileName);
                }
                else
                {
                    ModelState.AddModelError("", "Bạn phải nhập vào trường này");
                }
                


            }
            catch (System.Exception)
            {

                return View(obj);
            }
            return View();
        }

        
    }
}