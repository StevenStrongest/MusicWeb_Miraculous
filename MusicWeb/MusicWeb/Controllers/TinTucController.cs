using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        public ActionResult Index()
        {
            TintucDAO tt = new TintucDAO();
            var newPaer = tt.ListOf();
            ViewBag.TinTuc = newPaer;
            return View(newPaer);
        }

        public ActionResult ChiTietTinTuc(int id)
        {
            TintucDAO tt = new TintucDAO();
            var detail = tt.Detail(id);
            return View(detail);
        }
    }
}