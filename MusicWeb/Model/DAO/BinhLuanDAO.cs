using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BinhLuanDAO
    {
        MusicDBContext context;
        public BinhLuanDAO()
        {
            context = new MusicDBContext();
        }

        public void Add(BinhLuan bl)
        {
            bl.ThoiGian = DateTime.Now;
            context.BinhLuans.Add(bl);
            context.SaveChanges();
        }

        public object ListOf()
        {
            context.Configuration.ProxyCreationEnabled = false;
            var bl = from x in context.BinhLuans
                     join
                    b in context.NguoiDungs on
                    x.IdNguoiDung equals b.IdNguoiDung
                     select new
                     {
                         IdNguoiDung = b.IdNguoiDung,
                         IdChung = x.Idchung,
                         NoiDungBinhLuan = x.NoiDungBinhLuan,
                         ThuocTinh = x.ThuocTinh,
                         TaiKhoan = b.TaiKhoan,
                         AnhDaiDien = b.AnhDaiDien
                     };
            return bl;
        }

        public List<BinhLuan> List()
        {
            List<BinhLuan> Listkv = new List<BinhLuan>();
            Listkv = context.BinhLuans.ToList();
            return Listkv;
        }
        public void Delete(int id)
        {
            var sp = context.BinhLuans.SingleOrDefault(x => x.IdBinhLuan == id);
            if (sp != null)
            {
                context.BinhLuans.Remove(sp);
                context.SaveChanges();
            }
        }
    }
}
