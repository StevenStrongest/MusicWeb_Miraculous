using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            AlbumDAO al = new AlbumDAO();
            //Tất cả album
            var allAlbum = al.Listof();
            ViewBag.TatCaAlbum = allAlbum;
            //Album Hot
            var albumHot = al.AlbumHot();
            ViewBag.AlbumHot = albumHot;
            //Bai hát Theo Album
            var listBh = al.BaiHatByAlbum();
            ViewBag.BaiHatTheoAlbum = listBh;
            return View();
        }

        public ActionResult TatCaAlbum()
        {

            AlbumDAO al = new AlbumDAO();
            //Tất cả album
            var allAlbum = al.Listof();
            return View(allAlbum);
        }

        public ActionResult AlbumDetail(int id)
        {
            AlbumDAO al = new AlbumDAO();
            var album = al.Detail(id);
            BaiHatDAO bh = new BaiHatDAO();
            ViewBag.BaiHatTheoAlbum = bh.BaiHatTheoAlbum(id);
            return View(album);
        }
    }
}