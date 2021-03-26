using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class TheLoaiDAO
    {
        MusicDBContext context;
        public TheLoaiDAO()
        {
            context = new MusicDBContext();
        }
        public List<TheLoai> ListOf()
        {
            List<TheLoai> Listtt = new List<TheLoai>();
            Listtt = context.TheLoais.ToList();
            return Listtt;
        }
        public TheLoai Detail(int id)
        {
            var result = context.TheLoais.SingleOrDefault(x => x.IdTheLoai == id);
            return result;
        }
        public int AddNew(TheLoai obj)
        {
            var result = context.TheLoais.Add(obj);
            if (result != null)
            {
                context.SaveChanges();
                return result.IdTheLoai;
            }
            return -1;
        }
        public bool Update(TheLoai obj)
        {
            var sp = context.TheLoais.SingleOrDefault(x => x.IdTheLoai == obj.IdTheLoai);
            if (sp != null)
            {
                sp.TenTheLoai = obj.TenTheLoai;
                sp.AnhTheLoai = obj.AnhTheLoai;
               

                context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Delete(int id)
        {
            var sp = context.TheLoais.SingleOrDefault(x => x.IdTheLoai == id);
            if (sp != null)
            {
                context.TheLoais.Remove(sp);
                context.SaveChanges();
            }
        }

        //Thể Loại IEnumeable
        public IEnumerable<TheLoai> TheLoaiListIEnnumable()
        {
            var tl = context.TheLoais.Select(x=>x);
            return tl;
        }
    }
}
