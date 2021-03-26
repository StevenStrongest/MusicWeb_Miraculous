
using Model;
using Model.DAO;
using MusicWeb.Areas.Admin.Data;
using MusicWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MusicWeb.Areas.Admin.Controllers
{
    public class AdBaiHatController : SessionController
    {
        // GET: Admin/AdBaiHat
        public ActionResult CheckSession()
        {
            if (Session["TaiKhoan1"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        public ActionResult Index()
        {

            BaiHatDAO dao = new BaiHatDAO();
            var result = dao.ListOf();
            var list = new List<Data.BaiHatModelAdmin>();
            foreach (var item in result)
            {
                string tenAlbum = item.Album == null ? string.Empty : item.Album.TenAlbum;
                var bh = new Data.BaiHatModelAdmin(item.IdBaiHat,
                    item.TenBaiHat,
                    item.AnhBaiHat,
                    item.LoiBaihat,
                    item.NgayPhatHanh.HasValue ? item.NgayPhatHanh.Value : DateTime.Now,
                    item.Top100.HasValue ? item.Top100.Value : false,
                    item.LuotNghe.HasValue ? item.LuotNghe.Value : 0,
                    item.LuotTai.HasValue ? item.LuotTai.Value : 0,
                    item.LuotThich.HasValue ? item.LuotThich.Value : 0,
                    item.LinkBaiHat,
                    item.IdNgheSi.HasValue ? item.IdNgheSi.Value : -1,
                    item.IdTheLoai.HasValue ? item.IdTheLoai.Value : -1,
                    item.IdAlbum.HasValue ? item.IdAlbum.Value : -1,
                    tenAlbum,
                    item.NgheSi.TenNgheSi,
                    item.TheLoai.TenTheLoai
                    );
                list.Add(bh);

            }
            return View(list);
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            BaiHatDAO dao = new BaiHatDAO();
            var result = dao.Detail(id);
            if (result == null)
            {
                ViewBag.Message = "khong tim thay bai hat!";

            }
            if (result != null)
            {
                ViewBag.Message = "Thông tin chi tiết bài hát!";

            }
            string tenAlbum = result.Album == null ? string.Empty : result.Album.TenAlbum;
            Data.BaiHatModelAdmin md = new Data.BaiHatModelAdmin(result.IdBaiHat,
                result.TenBaiHat,
                result.AnhBaiHat,
                result.LoiBaihat,
                result.NgayPhatHanh.HasValue ? result.NgayPhatHanh.Value : DateTime.Now,
                result.Top100.HasValue ? result.Top100.Value : false,
                result.LuotNghe.HasValue ? result.LuotNghe.Value : 0,
                result.LuotTai.HasValue ? result.LuotTai.Value : 0,
                result.LuotThich.HasValue ? result.LuotThich.Value : 0,
                result.LinkBaiHat,
                result.IdNgheSi.HasValue ? result.IdNgheSi.Value : -1,
                result.IdTheLoai.HasValue ? result.IdTheLoai.Value : -1,
                result.IdAlbum.HasValue ? result.IdAlbum.Value : -1,
                tenAlbum,
                result.NgheSi.TenNgheSi,
                result.TheLoai.TenTheLoai);
            return View(md);
        }
        public ActionResult Update(int id)
        {
            TheLoaiDAO tldao = new TheLoaiDAO();
            var category = tldao.ListOf();
            NgheSiDAO nsdao = new NgheSiDAO();
            var nghesi = nsdao.Listof();
            AlbumDAO abdao = new AlbumDAO();
            var album = abdao.Listof();

            ViewBag.category = category;
            ViewBag.nghesi = nghesi;
            ViewBag.album = album;
            BaiHatDAO dao = new BaiHatDAO();
            var rs = dao.Detail(id);
            return View(rs);
        }
        [HttpPost]
        public ActionResult Update(BaiHat obj, HttpPostedFileBase file, FormCollection f)
        {
            BaiHatDAO dao = new BaiHatDAO();
            try
            {
                if (file!=null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName += "_" + obj.IdBaiHat;
                    fileName += Path.GetExtension(file.FileName);

                    string folderPath = Server.MapPath("~") + @"\Areas\Admin\Asset\ImagesOutSource\imgsong";
                    string folderPath2 = Server.MapPath("~") + @"/Assets/images/ImagesOutSource/ImagesSong";

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string path = Path.Combine(folderPath, fileName);
                    string path2 = Path.Combine(folderPath2, fileName);

                    file.SaveAs(path);
                    file.SaveAs(path2);
                    obj.AnhBaiHat = fileName;
                    obj.IdNgheSi = Convert.ToInt32(f["getNgheSi"]);
                    if (dao.Update(obj))
                    {
                        return RedirectToAction("Index", "AdBaiHat");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error");
                        return View(obj.IdBaiHat);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Bạn phải nhập vào trường này");
                }
            }
            catch
            {

            }
            TheLoaiDAO tldao = new TheLoaiDAO();
            var category = tldao.ListOf();
            NgheSiDAO nsdao = new NgheSiDAO();
            var nghesi = nsdao.Listof();
            AlbumDAO abdao = new AlbumDAO();
            var album = abdao.Listof();

            ViewBag.category = category;
            ViewBag.nghesi = nghesi;
            ViewBag.album = album;
            return View();

        }
        public ActionResult Add()
        {
            TheLoaiDAO tldao = new TheLoaiDAO();
            var category = tldao.ListOf();
            NgheSiDAO nsdao = new NgheSiDAO();
            var nghesi = nsdao.Listof();
            AlbumDAO abdao = new AlbumDAO();
            var album = abdao.Listof();

            ViewBag.category = category;
            ViewBag.nghesi = nghesi;
            ViewBag.album = album;

            return View();
        }
        [HttpPost]
        public ActionResult Add(BaiHat obj, NgheSi obj2, HttpPostedFileBase file, HttpPostedFileBase fileMusic, FormCollection f)
        {
            NgheSiDAO dao2 = new NgheSiDAO();
            BaiHatDAO dao = new BaiHatDAO();

            try
            {
                if (file!=null && file.ContentLength > 0)
                {
                    //anh bai hat
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName += "_" + obj.IdBaiHat;
                    fileName += Path.GetExtension(file.FileName);

                    string folderPath = Server.MapPath("~") + @"\Assets\images\ImagesOutSource\ImagesSong";

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string path = Path.Combine(folderPath, fileName);

                    file.SaveAs(path);
                    //anh nghe si
                    string fileName2 = Path.GetFileNameWithoutExtension(fileMusic.FileName);

                    //fileName2 += "_" + obj.LinkBaiHat;
                    fileName2 += Path.GetExtension(fileMusic.FileName);

                    string folderPath2 = Server.MapPath("~") + @"\MusicDowload";

                    if (!Directory.Exists(folderPath2))
                    {
                        Directory.CreateDirectory(folderPath2);
                    }

                    string path2 = Path.Combine(folderPath2, fileName2);
                    fileMusic.SaveAs(path2);

                    obj.AnhBaiHat = fileName;
                    obj.LinkBaiHat = fileName2;
                    obj.IdNgheSi = Convert.ToInt32(f["getNgheSi"]);
                    int id = dao.AddNew(obj);


                    if (id != -1)
                    {
                        return RedirectToAction("Add", "AdBaiHat");
                    }


                    else
                    {
                        ViewBag.Message("Thêm mới không thành công!");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Bạn phải nhập vào trường này");
                }
            }
            catch
            {

            }
            TheLoaiDAO tldao = new TheLoaiDAO();
            var category = tldao.ListOf();
            NgheSiDAO nsdao = new NgheSiDAO();
            var nghesi = nsdao.Listof();
            AlbumDAO abdao = new AlbumDAO();
            var album = abdao.Listof();

            ViewBag.category = category;
            ViewBag.nghesi = nghesi;
            ViewBag.album = album;
            return View();
        }

        [HttpGet]
        public ActionResult Del(int id)
        {
            BaiHatDAO dao = new BaiHatDAO();
            dao.Delete(id);
            return RedirectToAction("Index", "AdBaiHat");
        }
        public FileResult PlayFile(string FilePath)
        {
            return new FilePathResult(FilePath, "audio/ogg");
        }
    }
}