using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Model.DAO;
using MusicWeb.Areas.Admin.Data;
namespace MusicWeb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login login)
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
                if (dao.Login(login.Username, login.Password))
                {
                    var user = dao.GetByID(login.Username);
                    var userSession = new Login();
                    userSession.Username = user.TaiKhoan1;
                    userSession.ID = user.IdTaiKhoan;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    Session["TaiKhoan1"] = login.Username;
                    Session["KiemTra"] = user.IdTaiKhoan;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "username or password false");
                }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        
    }
}