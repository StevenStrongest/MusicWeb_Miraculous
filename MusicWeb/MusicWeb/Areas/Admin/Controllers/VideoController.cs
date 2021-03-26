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
    public class VideoController : SessionController
    {
        VideoDAO dao = new VideoDAO();
        // GET: Admin/Video
        public ActionResult Index()
        {
            var result = dao.ListOf();
            return View(result);
        }
        public ActionResult AddNew()
        {
            NgheSiDAO nsdao = new NgheSiDAO();
            var ns = nsdao.Listof();
            KhuVucDAO kvdao = new KhuVucDAO();
            var kv = kvdao.ListOf();
            ViewBag.ns = ns;
            ViewBag.kv = kv;
            return View();

        }
        [HttpPost]
        public ActionResult AddNew(Video obj, HttpPostedFileBase videofile, HttpPostedFileBase file)
        {

            try
            {


                if (videofile != null && videofile.ContentLength > 0 && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(videofile.FileName);
                    fileName += "_" + obj.IdVideo;
                    fileName += Path.GetExtension(videofile.FileName);

                    string folderPath = Server.MapPath("~") + @"\VideoDowLoad";

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string path = Path.Combine(folderPath, fileName);

                    videofile.SaveAs(path);
                    obj.LinkVideoMp4 = fileName;
                    string fileName1 = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName1 += "_" + obj.IdVideo;
                    fileName1 += Path.GetExtension(file.FileName);

                    string folderPath1 = Server.MapPath("~") + @"\Assets\images\PosterVideo";

                    if (!Directory.Exists(folderPath1))
                    {
                        Directory.CreateDirectory(folderPath1);
                    }

                    string path1 = Path.Combine(folderPath1, fileName1);

                    file.SaveAs(path1);
                    obj.Poster = fileName1;
                    int id = dao.AddNew(obj);
                    if (id != -1)
                    {
                        return RedirectToAction("Index", "Video");
                    }
                    else
                    {
                        ViewBag.Message("Them moi khong thanh cong");
                        return RedirectToAction("AddNew", "Video");
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
            NgheSiDAO nsdao = new NgheSiDAO();
            var ns = nsdao.Listof();
            KhuVucDAO kvdao = new KhuVucDAO();
            var kv = kvdao.ListOf();
            ViewBag.ns = ns;
            ViewBag.kv = kv;
            return View();



        }
        public ActionResult Update(int id)
        {
            NgheSiDAO nsdao = new NgheSiDAO();
            var ns = nsdao.Listof();
            KhuVucDAO kvdao = new KhuVucDAO();
            var kv = kvdao.ListOf();
            ViewBag.ns = ns;
            ViewBag.kv = kv;
            var ud = dao.GetVideoById(id);
            return View(ud);
        }
        [HttpPost]
        public ActionResult Update(Video obj, HttpPostedFileBase file, HttpPostedFileBase videofile)
        {
            try
            {

                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(videofile.FileName);
                    fileName += "_" + obj.IdVideo;
                    fileName += Path.GetExtension(videofile.FileName);

                    string folderPath = Server.MapPath("~") + @"\VideoDowload";

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string path = Path.Combine(folderPath, fileName);

                    videofile.SaveAs(path);
                    obj.LinkVideoMp4 = fileName;

                    string fileName1 = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName1 += "_" + obj.IdVideo;
                    fileName1 += Path.GetExtension(file.FileName);

                    string folderPath1 = Server.MapPath("~") + @"\Assets\images\PosterVideo";

                    if (!Directory.Exists(folderPath1))
                    {
                        Directory.CreateDirectory(folderPath1);
                    }

                    string path1 = Path.Combine(folderPath1, fileName1);

                    file.SaveAs(path1);
                    obj.Poster = fileName1;
                    if (dao.Update(obj))
                    {

                        return RedirectToAction("Index", "Video");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Error");
                        return View(obj.IdVideo);
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
            NgheSiDAO nsdao = new NgheSiDAO();
            var ns = nsdao.Listof();
            KhuVucDAO kvdao = new KhuVucDAO();
            var kv = kvdao.ListOf();
            ViewBag.ns = ns;
            ViewBag.kv = kv;
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            dao.Delete(id);
            return RedirectToAction("Index", "Video");
        }
    }
}