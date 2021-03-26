using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Areas.Admin.Controllers
{
    public class HomeController : SessionController
    {
        // GET: Admin/Home
       
        public ActionResult Index()
        {
            return View();
        }
    }
}