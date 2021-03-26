using Model;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWeb.Controllers
{
    public class HomePartialController : Controller
    {
        // GET: HomePartial
        
        //BannerPartial
        public ActionResult Banner()
        {
            return PartialView();
        }

        //NgheGanDayPartial
        public ActionResult NgheGanDay()
        {

            return PartialView();
        }

        public ActionResult Top15BaiHat()
        {
            return PartialView();
        }
    }
}