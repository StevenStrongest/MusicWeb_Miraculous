using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class LoaiTaiKhoanDAO
    {
        MusicDBContext context;
        public LoaiTaiKhoanDAO()
        {
            context = new MusicDBContext();
        }
        public List<LoaiTaiKhoan> ListOf()
        {
            List<LoaiTaiKhoan> Listkv = new List<LoaiTaiKhoan>();
            Listkv = context.LoaiTaiKhoans.ToList();
            return Listkv;
        }
        public LoaiTaiKhoan Detail(int id)
        {
            var result = context.LoaiTaiKhoans.SingleOrDefault(x => x.IdLoaiTaiKhoan == id);
            return result;
        }
        public int AddNew(LoaiTaiKhoan obj)
        {
            var result = context.LoaiTaiKhoans.Add(obj);
            if (result != null)
            {
                context.SaveChanges();
                return result.IdLoaiTaiKhoan;
            }
            return -1;
        }
        public bool Update(LoaiTaiKhoan obj)
        {
            var sp = context.LoaiTaiKhoans.SingleOrDefault(x => x.IdLoaiTaiKhoan == obj.IdLoaiTaiKhoan);
            if (sp != null)
            {
                sp.LoaiTaiKhoan1 = obj.LoaiTaiKhoan1;


                context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Delete(int id)
        {
            var sp = context.LoaiTaiKhoans.SingleOrDefault(x => x.IdLoaiTaiKhoan == id);
            if (sp != null)
            {
                context.LoaiTaiKhoans.Remove(sp);
                context.SaveChanges();
            }
        }
    }
}
