using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class NgheSiDAO
    {
        MusicDBContext context;
        public NgheSiDAO()
        {
            context = new MusicDBContext();
        }
        public List<NgheSi> Listof()
        {
            List<NgheSi> listNS = new List<NgheSi>();
            listNS = context.NgheSis.ToList();
            return listNS;
        }

        public int AddNew(NgheSi obj)
        {
            var result = context.NgheSis.Add(obj);
            if (result != null)
            {
                context.SaveChanges();
                return result.IdNgheSi;
            }
            return -1;
        }
        public bool Update(NgheSi obj)
        {
            var ns = context.NgheSis.SingleOrDefault(x => x.IdNgheSi == obj.IdNgheSi);
            if (ns != null)
            {
                ns.TenNgheSi = obj.TenNgheSi;
                ns.AnhNgheSi = obj.AnhNgheSi;
                ns.IdKhuVuc = obj.IdKhuVuc;
                ns.LuotQuanTam = obj.LuotQuanTam;
                ns.Hot = obj.Hot;
                

                context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(int id)
        {
            var ns = context.NgheSis.SingleOrDefault(x => x.IdNgheSi == id);
            if (ns != null)
            {
                context.NgheSis.Remove(ns);
                context.SaveChanges();
            }
        }

        public NgheSi Detail(int id)
        {
            var result = context.NgheSis.SingleOrDefault(x => x.IdNgheSi == id);
            return result;
        }

        public bool Upload(int id, string imgName)
        {
            var sp = context.NgheSis.SingleOrDefault(x => x.IdNgheSi == id);
            if (sp != null)
            {
                sp.AnhNgheSi = imgName;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<NgheSi> ListNgheSiHot()
        {
            var ns = context.NgheSis.Where(x => x.Hot == true).ToList();

            return ns;
        }

        public NgheSi GetNgheSiById(int id)
        {
            var ngheSi = context.NgheSis.SingleOrDefault(x => x.IdNgheSi == id);
            return ngheSi;
        }

        public List<NgheSi> LocNgheSiTheoKhuVuc(int kv)
        {
            var nghesi = context.NgheSis.Where(t => t.IdKhuVuc == kv).ToList();
            return nghesi;
        }
    }
}
