using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model;

namespace MusicWeb.Areas.Admin.Controllers
{
    public class BinhLuanController : Controller
    {
        // GET: Admin/BinhLuan
        BinhLuanDAO dao = new BinhLuanDAO();
        public ActionResult Index()
        {
            var result = dao.List();
            return View(result);
        }
        public ActionResult Delete(int id)
        {

            dao.Delete(id);

            return RedirectToAction("Index", "BinhLuan");
        }
    }
}