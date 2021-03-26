using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class KhuVucDAO
    {
        MusicDBContext context;
        public KhuVucDAO()
        {
            context = new MusicDBContext();
        }
        public List<KhuVuc> ListOf()
        {
            List<KhuVuc> Listkv = new List<KhuVuc>();
            Listkv = context.KhuVucs.ToList();
            return Listkv;
        }
        public KhuVuc Detail(int id)
        {
            var result = context.KhuVucs.SingleOrDefault(x => x.IdKhuVuc == id);
            return result;
        }
        public int AddNew(KhuVuc obj)
        {
            var result = context.KhuVucs.Add(obj);
            if (result != null)
            {
                context.SaveChanges();
                return result.IdKhuVuc;
            }
            return -1;
        }
        public bool Update(KhuVuc obj)
        {
            var sp = context.KhuVucs.SingleOrDefault(x => x.IdKhuVuc == obj.IdKhuVuc);
            if (sp != null)
            {
                sp.TenKhuVuc = obj.TenKhuVuc;
           

                context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Delete(int id)
        {
            var sp = context.KhuVucs.SingleOrDefault(x => x.IdKhuVuc == id);
            if (sp != null)
            {
                context.KhuVucs.Remove(sp);
                context.SaveChanges();
            }
        }
    }
}
