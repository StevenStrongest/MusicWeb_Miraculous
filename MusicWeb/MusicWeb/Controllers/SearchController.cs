using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpGet]
        public ActionResult Index(string txtSerach)
        {
            TimKiemDAO tk = new TimKiemDAO();
            var rs = tk.TimKiem(txtSerach);
            ViewBag.KetQuaTimKiem = txtSerach;
            return View(rs);
        }
    }
}