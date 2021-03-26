using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicWeb.Models;
using Model.DAO;

namespace MusicWeb.Controllers
{
    public class DanhSachPhatController : Controller
    {
        // GET: DanhSachPhat
        private List<DanhSachPhatItem> list = new List<DanhSachPhatItem>();

        // GET: Cart
        private const string CartSession = "CartSession";
        [HttpGet]
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<DanhSachPhatItem>();
            if (cart != null)
            {
                list = (List<DanhSachPhatItem>)cart;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddDanhSachPhat(int id)
        {
            BaiHatDAO bh = new BaiHatDAO();
            var data = bh.GetBaiHatById(id);
            //Tạo Mới Cart Item
            var cart = Session[CartSession];
            if (cart != null)
            {
                this.list = (List<DanhSachPhatItem>)cart;
                if (this.list.Exists(x => x.BaiHat.IdBaiHat == id))
                {
                    foreach (var item in this.list.ToList())
                    {
                        if (item.BaiHat.IdBaiHat == id)
                        {

                        }
                    }
                }
                else
                {
                    var i = new DanhSachPhatItem();
                    i.BaiHat = data;
                    this.list.Add(i);
                    //Gán vào Session
                    Session[CartSession] = this.list;
                }
            }
            else
            {
                var item = new DanhSachPhatItem();
                item.BaiHat = data;
                this.list.Add(item);
                //Gán vào Session
                Session[CartSession] = this.list;
            }

            return Json(this.list.Distinct(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RemoveQueue(int id)
        {
            var cart = (List<DanhSachPhatItem>)Session[CartSession];
            cart.RemoveAll(x => x.BaiHat.IdBaiHat == id);
            
            return Json(cart, JsonRequestBehavior.AllowGet);
        }

           
    }
}