using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BaiHatYeuThichDAO
    {
        MusicDBContext context;

        public BaiHatYeuThichDAO()
        {
            context = new MusicDBContext();
        }

        public void Add(BaiHatYeuThich bh)
        {
            context.BaiHatYeuThiches.Add(bh);
            context.SaveChanges();
        }

        public bool KiemTra(int idBaiHat, int idNguoiDung)
        {
            var x = context.BaiHatYeuThiches.SingleOrDefault(v => v.IdBaiHat == idBaiHat && v.IdNguoiDung == idNguoiDung);
            if (x != null)
                return false;
            return true;
        }

        public BaiHatYeuThich Detail(int id, int idNguoiDung, string tt)
        {
            var bh = context.BaiHatYeuThiches.SingleOrDefault(x => x.IdBaiHat == id && x.IdNguoiDung == idNguoiDung);
            return bh;
        }

        public void UpdateTrangThai(BaiHatYeuThich bh)
        {
            var y = context.BaiHatYeuThiches.SingleOrDefault(x => x.IdBaiHat == bh.IdBaiHat && x.IdNguoiDung == bh.IdNguoiDung);
            if(y == null)
            {
                context.BaiHatYeuThiches.Add(bh);
                context.SaveChanges();
            }
            else
            {
                y.TrangThaiThich = bh.TrangThaiThich;
                context.SaveChanges();
            }
        }

        public bool KiemTraTrangThai(string tt, int idNguoiDung)
        {
            var x = context.BaiHatYeuThiches.SingleOrDefault(v => v.TrangThaiThich == tt && v.IdNguoiDung == idNguoiDung);
            if (x != null)
                return false;
            return true;
        }

        public void Delete(int idBaiHat, int idNguoiDung)
        {
            var x = context.BaiHatYeuThiches.SingleOrDefault(v => v.IdBaiHat == idBaiHat && v.IdNguoiDung == idNguoiDung);
            context.BaiHatYeuThiches.Remove(x);
            context.SaveChanges();
        }

        public object ListBaiHatYeuThich(int id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var bl = from x in context.BaiHatYeuThiches
                     join
                    b in context.BaiHats on
                    x.IdBaiHat equals b.IdBaiHat
                     where x.IdBaiHat == b.IdBaiHat && x.IdNguoiDung == id
                     select new
                     {
                         IdBaiHat = x.IdBaiHat,
                         TenBaiHat = b.TenBaiHat,
                         AnhBaiHat = b.AnhBaiHat,
                         LinkChiaSe = b.LinkChiaSe,
                         IdNguoiDung = x.IdNguoiDung,
                         IdBaiHatYeuThich = x.IdBaiHatYeuThich,
                         TrangThaiThich = x.TrangThaiThich
                     };
            return bl;
        }
    }
}
