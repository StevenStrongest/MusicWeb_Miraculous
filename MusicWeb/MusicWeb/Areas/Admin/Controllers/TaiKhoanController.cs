using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model;

namespace MusicWeb.Areas.Admin.Controllers
{
    public class TaiKhoanController : SessionController
    {
        // GET: Admin/TaiKhoan
        TaiKhoanDAO dao = new TaiKhoanDAO();
        public ActionResult Index()
        {
            var result = dao.Listof();

            return View(result);
        }
        public ActionResult AddNew()
        {
            LoaiTaiKhoanDAO tkdao = new LoaiTaiKhoanDAO();
            var ltk = tkdao.ListOf();
            ViewBag.ltk = ltk;

            return View();
        }

        [HttpPost]
        public ActionResult AddNew(TaiKhoan obj)
        {
            if(obj.TaiKhoan1 != null && obj.MatKhau != null)
            {
                int id = dao.AddNew(obj);

                if (id != -1)
                {
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else
                {
                    ViewBag.Message("Them moi khong thanh cong");
                    return RedirectToAction("AddNew", "TaiKhoan");
                }
            }
            else
            {
                ModelState.AddModelError("", "Bạn phải nhập vào trường này");
            }
            LoaiTaiKhoanDAO tkdao = new LoaiTaiKhoanDAO();
            var ltk = tkdao.ListOf();
            ViewBag.ltk = ltk;

            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if(Session["KiemTra"] != null)
            {
                if(id != (int)Session["KiemTra"])
                {                   
                    dao.Delete(id);
                    return Json("thanhcong", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Tài khoản hiện đang hoạt động", JsonRequestBehavior.AllowGet);                 
                    
                }
            }
           
            return RedirectToAction("Index", "TaiKhoan");
        }
        public ActionResult Update(int id)
        {
            LoaiTaiKhoanDAO tkdao = new LoaiTaiKhoanDAO();
            var ltk = tkdao.ListOf();
            ViewBag.ltk = ltk;
            var up = dao.Detail(id);
            return View(up);
        }
        [HttpPost]
        public ActionResult Update(TaiKhoan obj)
        {
            if (dao.Update(obj))
            {
                return RedirectToAction("Index", "TaiKhoan");
            }
            else
            {
                ModelState.AddModelError("", "Error");
                return View(obj.IdTaiKhoan);
            }
        }
        public ActionResult InfoUser(int id)
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            var result = dao.Detail(id);
            return View(result);
        }
    }
}