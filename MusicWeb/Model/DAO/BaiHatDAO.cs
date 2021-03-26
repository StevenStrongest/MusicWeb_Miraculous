using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class BaiHatDAO
    {
        MusicDBContext context;
        public BaiHatDAO()
        {
            context = new MusicDBContext();
        }
        public List<BaiHat> PhanTrang(int baihatid, ref int total, int pageIndex =1,int pageSize = 2)
        {
            total = context.BaiHats.Where(x => x.IdBaiHat == baihatid).Count();
            var model =  context.BaiHats.Where(x => x.IdBaiHat == baihatid).Skip((pageSize - 1) * pageIndex).Take(pageSize).ToList();
            return model;
        }
        public List<BaiHat> ListOf()
        {
            List<BaiHat> ListSP = new List<BaiHat>();
            ListSP = context.BaiHats.ToList();
            return ListSP;
        }
        public BaiHat Detail(int id)
        {
            var result = context.BaiHats.SingleOrDefault(x => x.IdBaiHat == id);
            return result;
        }
        public int AddNew(BaiHat obj)
        {
            obj.LuotNghe = 0;
            obj.LuotThich = 0;
            obj.LuotTai = 0;
            obj.Top100 = false;
            var result = context.BaiHats.Add(obj);
            if (result != null)
            {
                context.SaveChanges();
                return result.IdBaiHat;
            }
            return -1;
        }

        public bool Update(BaiHat obj)
        {
            var sp = context.BaiHats.SingleOrDefault(x => x.IdBaiHat == obj.IdBaiHat);
            if (sp != null)
            {
                sp.TenBaiHat = obj.TenBaiHat;
                sp.AnhBaiHat = obj.AnhBaiHat;
                sp.LoiBaihat = obj.LoiBaihat;
                sp.NgayPhatHanh = obj.NgayPhatHanh;
                sp.Top100 = true;
                sp.LuotNghe = obj.LuotNghe;
                sp.LuotTai = obj.LuotTai;
                sp.LuotThich = obj.LuotThich;
                //sp.LinkBaiHat = obj.LinkBaiHat;
                sp.IdNgheSi = obj.IdNgheSi;
                sp.IdTheLoai = obj.IdTheLoai;
                sp.IdAlbum = obj.IdAlbum;

                context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Delete(int id)
        {
            var sp = context.BaiHats.SingleOrDefault(x => x.IdBaiHat == id);
            if (sp != null)
            {
                context.BaiHats.Remove(sp);
                context.SaveChanges();
            }
        }

        public bool Upload(int id, string imgName)
        {
            var sp = context.BaiHats.SingleOrDefault(x => x.IdBaiHat == id);
            if (sp != null)
            {
                sp.AnhBaiHat = imgName;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public BaiHat GetByIDAudio(int id)
        {
            return context.BaiHats.SingleOrDefault(x => x.IdBaiHat == id);
        }

        //15 bai hat hay
        public IEnumerable<BaiHat> Top15()
        {
            var bh = context.BaiHats.Where(n => n.Top100 == true);

            return bh;
        }
        //Lay Bai Hat Theo ID
        public BaiHat GetBaiHatById(int id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            BaiHat bh = new BaiHat();
            bh = context.BaiHats.SingleOrDefault(n => n.IdBaiHat == id);
            return bh;
        }

        public BaiHat GetBaiHatById2(int id)
        {
            BaiHat bh = context.BaiHats.SingleOrDefault(n => n.IdBaiHat == id);
            return bh;
        }
        //List Bài Hát Mới Phát Hành
        public List<BaiHat> MoiPhatHanh()
        {
            var bh = context.BaiHats.SqlQuery("select * from BaiHat where MONTH(GETDATE()) - MONTH(NgayPhatHanh) < 12 and YEAR(GETDATE()) - YEAR(NgayPhatHanh) < 2").ToList();
            return bh;
        }
        //Bài hát IEnumalble
        public IEnumerable<BaiHat> DanhSachBaiHatIEnumerable()
        {
            var bh = context.BaiHats;
            return bh;
        }
        //Lấy Bài Hát Theo Nghệ Sĩ
        public List<BaiHat> GetBaiHatByIdNgheSi(int id)
        {
            List<BaiHat> list = new List<BaiHat>();
            list = context.BaiHats.Where(x => x.IdNgheSi == id).ToList();
            return list;
        }
        //Cập nhật View
        public void UpdateViews(int id)
        {
            var bh = context.BaiHats.Find(id);
            bh.LuotNghe += 1;
            context.SaveChanges();
        }

        public List<BaiHat> BaiHatTheoAlbum(int id)
        {
            List<BaiHat> list = new List<BaiHat>();
            list = context.BaiHats.Where(x => x.IdAlbum == id).ToList();
            return list;
        }

        public List<BaiHat> GetBaiHatByTheLoai(int idTL)
        {
            return context.BaiHats.Where(x => x.IdTheLoai == idTL).ToList();
        }
    }
}
