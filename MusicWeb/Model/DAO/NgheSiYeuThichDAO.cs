using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class NgheSiYeuThichDAO
    {
        MusicDBContext context;
        public NgheSiYeuThichDAO()
        {
            context = new MusicDBContext();
        }

        public void Add(NgheSiYeuThich bh)
        {
            context.NgheSiYeuThiches.Add(bh);
            context.SaveChanges();
        }

        public bool KiemTra(int idNgheSi, int idNguoiDung)
        {
            var x = context.NgheSiYeuThiches.SingleOrDefault(v => v.IdNgheSi == idNgheSi && v.IdNguoiDung == idNguoiDung);
            if (x != null)
                return false;
            return true;
        }

        public void Delete(int idNgheSi, int idNguoiDung)
        {
            var x = context.NgheSiYeuThiches.SingleOrDefault(v => v.IdNgheSi == idNgheSi && v.IdNguoiDung == idNguoiDung);
            context.NgheSiYeuThiches.Remove(x);
            context.SaveChanges();
        }

        public object ListNgheSiYeuThich(int id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var bl = from x in context.NgheSiYeuThiches
                     join
                    b in context.NgheSis on
                    x.IdNgheSi equals b.IdNgheSi
                     where x.IdNgheSi == b.IdNgheSi && x.IdNguoiDung == id
                     select new
                     {
                         IdNgheSi = x.IdNgheSi,
                         TenNgheSi = b.TenNgheSi,
                         AnhNgheSi = b.AnhNgheSi
                     };
            return bl;
        }
    }
}
