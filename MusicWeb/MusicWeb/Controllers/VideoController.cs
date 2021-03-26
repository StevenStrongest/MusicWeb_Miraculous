using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListVideo()
        {
            VideoDAO video = new VideoDAO();
            var list = video.ListOf();
            ViewBag.TatCaVideo = list;
            ViewBag.VideoHot = list;
            return View();
        }

        [HttpGet]
        public JsonResult AllBinhLuan()
        {
            BinhLuanDAO bl = new BinhLuanDAO();
            var allBl = bl.ListOf();

            return Json(allBl, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PlayVideo(int id)
        {           
            VideoDAO video = new VideoDAO();
            var VideoId = video.GetVideoById(id);
            ViewBag.TatCaVideo = video.ListOf();
            Session["VideoById"] = VideoId;

            return View(VideoId);
        }
    }
}