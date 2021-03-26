using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class TaiKhoanDAO
    {
        MusicDBContext context;
        public TaiKhoanDAO()
        {
            context = new MusicDBContext();

        }

        public List<TaiKhoan> Listof()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            list = context.TaiKhoans.ToList();
            return list;
        }
        public TaiKhoan Detail(int id)
        {
            var result = context.TaiKhoans.SingleOrDefault(x => x.IdTaiKhoan == id);
            return result;
        }
        public int AddNew(TaiKhoan obj)
        {
            var result = context.TaiKhoans.Add(obj);
            if (result != null)
            {
                context.SaveChanges();
                return result.IdTaiKhoan;
            }
            return -1;
        }
        public bool Update(TaiKhoan obj)
        {
            var sp = context.TaiKhoans.SingleOrDefault(x => x.IdTaiKhoan == obj.IdTaiKhoan);
            if (sp != null)
            {
                sp.TaiKhoan1 = obj.TaiKhoan1;
                sp.MatKhau = obj.MatKhau;
                sp.IdLoaiTaiKhoan = obj.IdLoaiTaiKhoan;


                context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Delete(int id)
        {
            var sp = context.TaiKhoans.SingleOrDefault(x => x.IdTaiKhoan == id);
            if (sp != null)
            {
                context.TaiKhoans.Remove(sp);
                context.SaveChanges();
            }
        }
        public TaiKhoan GetByID(string userName)
        {
            return context.TaiKhoans.SingleOrDefault(x => x.TaiKhoan1 == userName);
        }

        public bool Login(string username, string password)
        {
            try
            {
                var listAcc = context.TaiKhoans.ToList();
                var acc = listAcc.SingleOrDefault(x => x.TaiKhoan1 == username && x.MatKhau == password);
                if (acc != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
