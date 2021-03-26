using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class NhacCaNhanDAO
    {
        MusicDBContext context;
        public NhacCaNhanDAO()
        {
            context = new MusicDBContext();
        }

        public List<NhacCaNhan> ListOf()
        {
            context.Configuration.ProxyCreationEnabled = false;
            return context.NhacCaNhans.ToList();
        }

        public void Delete(int id)
        {
            var nhac = context.NhacCaNhans.SingleOrDefault(x => x.IdNhacCaNhan == id);
            context.NhacCaNhans.Remove(nhac);
            context.SaveChanges();
        }

        public void Add(NhacCaNhan obj)
        {
            context.NhacCaNhans.Add(obj);
            context.SaveChanges();
        }
    }
}
