using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class ThongTinNgheSiController : Controller
    {
        // GET: ThongTinNgheSi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThongTin(int idNgheSi)
        {
            NgheSiDAO ns = new NgheSiDAO();
            var ngheSi = ns.GetNgheSiById(idNgheSi);
            BaiHatDAO bh = new BaiHatDAO();
            var dsbh = bh.GetBaiHatByIdNgheSi(idNgheSi);
            ViewBag.BaiHatTheoNgheSi = dsbh;
            //Nghệ Sĩ Khác
            ViewBag.NgheSiKhac = ns.ListNgheSiHot().Where(x => x.IdNgheSi != idNgheSi).ToList();
            return View(ngheSi);
        }
    }
}