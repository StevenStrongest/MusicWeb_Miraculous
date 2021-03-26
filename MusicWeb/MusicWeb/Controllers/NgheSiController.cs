using Model;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class NgheSiController : Controller
    {
        // GET: NgheSi
        public ActionResult Index()
        {
            NgheSiDAO ns = new NgheSiDAO();
            var nghesinoibat = ns.ListNgheSiHot();
            ViewBag.NgheSiHot = nghesinoibat;
            var tatcanghesi = ns.Listof();
            ViewBag.TatCaNgheSi = tatcanghesi;
            KhuVucDAO kv = new KhuVucDAO();
            var khuvuc = kv.ListOf();
            ViewBag.KhuVuc = khuvuc;
            return View();
        }

        public ActionResult NgheSiTheoKhuVuc(int IdKhuVuc)
        {       
            KhuVucDAO kv = new KhuVucDAO();
            var allkv = kv.ListOf();
            ViewBag.TatCaKhuVuc = allkv;
            NgheSiDAO ns = new NgheSiDAO();
            List<object> kvList = new List<object>();
            var x = ns.LocNgheSiTheoKhuVuc(IdKhuVuc);
            kvList.Add(x);
            ViewBag.KhuVuc = kvList;
            ViewBag.NgheSiTheoKhuVuc = x;
            return View();
        }
    }
}